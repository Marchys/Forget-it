using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;

public class ChoosePathButton : MonoBehaviour
{
    private bool _buttonReady;
    private Text _textComponent;
    private Image _imageComponent;
    private Button _buttonComponent;
    private readonly float[] _buttonEntryTimes = {2f, 2.2f, 2.4f, 2.6f, 2.8f, 3f};

    public ChoosePathButton Initialize()
    {
        _textComponent = GetComponentInChildren<Text>();
        if (_textComponent == null)
        {
            Debug.Log("Could not find text component");
        }
        _imageComponent = GetComponent<Image>();
        if (_imageComponent == null)
        {
            Debug.Log("Could not find image component");
        }
        _buttonComponent = GetComponent<Button>();
        if (_buttonComponent == null)
        {
            Debug.Log("Could not find button component");
        }
        Hide();
        Disable();
        return this;
    }

    public ChoosePathButton SetOption(string text)
    {
        _buttonReady = true;
        if (_textComponent == null)
        {
            Debug.Log("Text component not available");
            return this;
        }
        _textComponent.text = text;
        return this;
    }

    public ChoosePathButton StartEntry(int buttonIndex)
    {
        Show();
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 currentPosition = rectTransform.position;
        rectTransform.position = new Vector3(currentPosition.x, currentPosition.y-530, currentPosition.z);
        Tween tween = rectTransform.DOMove(currentPosition, _buttonEntryTimes[buttonIndex]).OnComplete(()=> Enable());
        tween.SetEase(Ease.OutQuint);
        return this;
    }

    public ChoosePathButton Hide()
    {
        _imageComponent.color = Color.clear;
        _textComponent.color = Color.clear;
        return this;
    }

    public ChoosePathButton Show()
    {
        _imageComponent.color = Color.white;
        _textComponent.color = Color.white;
        return this;
    }

    public ChoosePathButton Disable()
    {
        _buttonComponent.enabled = false;
        return this;
    }

    public ChoosePathButton Enable()
    {
        _buttonComponent.enabled = true;
        return this;

    }
}
