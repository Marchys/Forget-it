using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoosePathButton : MonoBehaviour
{
    private bool buttonReady;
    private Text textComponent;

    void Start()
    {
        Text textComponent = GetComponentInChildren<Text>();
        if (textComponent == null)
        {
            Debug.Log("Could not find text component");
        }
    }

    public ChoosePathButton setOption(string text)
    {
        buttonReady = true;
        if (textComponent == null)
        {
            return this;
        }
        textComponent.text = text;
        return this;
    }

 }
