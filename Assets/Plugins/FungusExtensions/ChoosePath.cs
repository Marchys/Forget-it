/**
 * This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
 * It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)
 */

using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

namespace Fungus
{
    [CommandInfo("Narrative",
                 "ChoosePath",
                 "Displays a button in a multiple choice animated menu")]
    [AddComponentMenu("")]
    public class ChoosePath : Command, ILocalizable
    {
        [Tooltip("Text to display on the menu button")]
        public string text = "Option Text";

        [Tooltip("Notes about the option text for other authors, localization, etc.")]
        public string description = "";

        [FormerlySerializedAs("targetSequence")]
        [Tooltip("Block to execute when this option is selected")]
        public Block targetBlock;

        [Tooltip("Hide this option if the target block has been executed previously")]
        public bool hideIfVisited;

        [Tooltip("If false, the menu option will be displayed but will not be selectable")]
        public BooleanData interactable = new BooleanData(true);

        [Tooltip("A custom Choose Path dialog to use to display this menu. All subsequent Menu commands will use this dialog.")]
        public ChoosePathDialog setChoosePathDialog;

        public override void OnEnter()
        {
            if (setChoosePathDialog != null)
            {
                // Override the active menu dialog
                ChoosePathDialog.activeMenuDialog = setChoosePathDialog;
            }

            bool hideOption = (hideIfVisited && targetBlock != null && targetBlock.GetExecutionCount() > 0);

            if (!hideOption)
            {
                ChoosePathDialog choosePathDialog = ChoosePathDialog.GetMenuDialog();
                if (choosePathDialog != null)
                {
                    choosePathDialog.gameObject.SetActive(true);

                    Flowchart flowchart = GetFlowchart();
                    string displayText = flowchart.SubstituteVariables(text);

                    choosePathDialog.AddOption(displayText, interactable, targetBlock);
                }
            }

            Continue();
        }

        public override void GetConnectedBlocks(ref List<Block> connectedBlocks)
        {
            if (targetBlock != null)
            {
                connectedBlocks.Add(targetBlock);
            }
        }

        public override string GetSummary()
        {
            if (targetBlock == null)
            {
                return "Error: No target block selected";
            }

            if (text == "")
            {
                return "Error: No button text selected";
            }

            return text + " : " + targetBlock.blockName;
        }

        public override Color GetButtonColor()
        {
            return new Color32(184, 210, 235, 255);
        }

        //
        // ILocalizable implementation
        //

        public virtual string GetStandardText()
        {
            return text;
        }

        public virtual void SetStandardText(string standardText)
        {
            text = standardText;
        }

        public virtual string GetDescription()
        {
            return description;
        }

        public virtual string GetStringId()
        {
            // String id for Menu commands is MENU.<Localization Id>.<Command id>
            return "MENU." + GetFlowchartLocalizationId() + "." + itemId;
        }
    }

}