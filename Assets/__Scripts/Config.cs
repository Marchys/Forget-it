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
                        new SayDialogBox("Standad",new Vector2(252, 6), 22, 32),
                        new SayDialogBox("Detective",new Vector2(252, 63), 22, 32),
                        new SayDialogBox("Kalzov",new Vector2(252, 6), 22, 32222222)
                 };
            }
        }

        public static SayDialogBox StandardConfig
        {
            get { return new SayDialogBox("Standad", new Vector2(252, 6), 22, 32); }
        }

        public enum DialogBoxTypes
        {
            Standard = 0,
            Detective = 1,
            Kalzov = 2,
        }
    }
}
