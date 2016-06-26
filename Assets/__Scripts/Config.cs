using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Messaging;

public static class Config
{
    public class DialogBox
    {
        public static SayDialogBox[] Configurations
        {
            get
            {
                return new[]
                {
                        new SayDialogBox("Standad",new Vector2(55, 586),new Vector2(437, 227), 875, 454),
                        new SayDialogBox("Detective",new Vector2(93, 57),new Vector2(532, 119), 685, 238),
                        new SayDialogBox("Kalzov",new Vector2(55, 586),new Vector2(437, 227), 875, 454)
                 };
            }
        }

        public static SayDialogBox StandardConfig
        {
            get { return new SayDialogBox("Standad", new Vector2(55, 586), new Vector2(437, 227), 875, 454) }
        }

        public enum DialogBoxTypes
        {
            Standard = 0,
            Detective = 1,
            Kalzov = 2,
        }
    }
}
