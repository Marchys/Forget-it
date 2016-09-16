using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;
using System;
using SRF;

public class ChoosePathButton : MonoBehaviour
{
    private bool _buttonReady;
    private Text _textComponent;
    private Image _imageComponent;
    private Button _buttonComponent;
    private RectTransform _rectTransform;
    private readonly float[] _buttonEntryTimes = { 2f, 2.2f, 2.4f, 2.6f, 2.8f, 3f };

    public ChoosePathButton Initialize()
    {
        _textComponent = GetComponentInChildren<Text>();
        _imageComponent = GetComponent<Image>();
        _buttonComponent = GetComponent<Button>();
        _rectTransform = GetComponent<RectTransform>();
        Hide();
        Disable();
        return this;
    }

    public ChoosePathButton SetOption(string text, Action onClick)
    {
        _buttonReady = true;
        if (_textComponent == null)
        {
            Debug.Log("Text component not available");
            return this;
        }
        _textComponent.text = text;
        _buttonComponent.onClick.AddListener(() => OnClick(onClick));
        return this;
    }

    public ChoosePathButton StartEntry(int buttonIndex)
    {
        Show();
        Vector3 currentPosition = _rectTransform.position;
        _rectTransform.position = new Vector3(currentPosition.x, currentPosition.y - 530, currentPosition.z);
        Tween tween = _rectTransform.DOMove(currentPosition, _buttonEntryTimes[buttonIndex], true).OnComplete(() => Enable());
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

    private ChoosePathButton OnClick(Action callback)
    {   
        _rectTransform.SetAsLastSibling();
        DOTween.defaultEaseType = Ease.OutQuart;
        Material material = Instantiate(_imageComponent.material);
        _imageComponent.material = material;

        Sequence flashSequence = DOTween.Sequence();
        flashSequence
            .Append(_imageComponent.material.DOFloat(1, "_FlashAmount", 0.1f))
            .Append(_imageComponent.material.DOFloat(0, "_FlashAmount", 0.1f))
            .Append(_imageComponent.material.DOFloat(1, "_FlashAmount", 0.1f))
            .Append(_imageComponent.material.DOFloat(0, "_FlashAmount", 0.1f))
            .SetEase(Ease.OutQuint);
        Sequence chooseSequence = DOTween.Sequence();
        chooseSequence
            .Append(_rectTransform.DOMove(new Vector3(413f, 200f, 0), 1.5f, true))
            .Join(flashSequence)
            .Append(_rectTransform.DOScale(new Vector3(10, 10, 0), 1f))
            .Join(_imageComponent.material.DOFloat(1, "_FlashAmount", 1f))
            .PrependInterval(1f)
            .OnComplete(() =>
            {
                Hide();
                callback();
            });
        return this;
    }

}
