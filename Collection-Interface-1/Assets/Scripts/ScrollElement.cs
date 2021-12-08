using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollElement : MonoBehaviour
{
    public Action<int> Click;

    private Button _button;
    [SerializeField] private Image _image;
    private int _index;
    private bool _isHide = false;

    public void Initialize(int index, Sprite sprite)
    {
        _button = GetComponent<Button>();
        _index = index;
        _image.sprite = sprite;
    }

    public void OnClick()
    {
        Click?.Invoke(_index);
    }

    public void SetSelect(bool value)
    {
        if (_isHide) return;
        _button.enabled = !value;
        _image.color = value ? Color.blue : Color.white;
    }

    public void SetHide(bool value)
    {
        _image.color = value ? Color.black : Color.white;
        _isHide = value;
    }
}