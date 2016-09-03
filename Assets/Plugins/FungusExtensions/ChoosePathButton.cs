using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoosePathButton : MonoBehaviour
{
    private bool buttonReady;
    private Text textComponent;
    private Image imageComponent;
    private Button buttonComponent;

    public ChoosePathButton Initialize()
    {
        textComponent = GetComponentInChildren<Text>();
        if (textComponent == null)
        {
            Debug.Log("Could not find text component");
        }
        imageComponent = GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.Log("Could not find image component");
        }
        buttonComponent = GetComponent<Button>();
        if (buttonComponent == null)
        {
            Debug.Log("Could not find button component");
        }
        Hide();
        return this;
    }

    public ChoosePathButton setOption(string text)
    {
        buttonReady = true;
        if (textComponent == null)
        {
            Debug.Log("Text component not available");
            return this;
        }
        textComponent.text = text;
        return this;
    }

    public ChoosePathButton Hide()
    {
        imageComponent.color = Color.clear;
        textComponent.color = Color.clear;
        buttonComponent.enabled = false;
        return this;
    }

    public ChoosePathButton Show()
    {
        imageComponent.color = Color.white;
        textComponent.color = Color.white;
        buttonComponent.enabled = true;
        return this;
    }

}
