using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InputType
{
    Model,
    Material
}

public class CastomizationControler : MonoBehaviour
{
    [SerializeField] private Texture2D _icon1;
    [SerializeField] private Texture2D _icon2;

    [SerializeField] private RawImage _image;
    [SerializeField] private Canvas _canvas;

    [SerializeField] private AddData _addData;


    private Customization[] _customizations;

    private Customization _customization = null;

    private System.Action Action;

    private void Awake()
    {
        _customizations = FindObjectsOfType<Customization>();

        foreach(Customization customization in _customizations)
        {
            customization.OpenDatabase += OpenDataSystem;
        }

        Disable();
    }

    public void Click()
    {
        Action();
    }

    private void Enable()
    {
        _image.texture = _icon2;
        foreach (Customization customization in _customizations)
        {
            customization.gameObject.SetActive(true);
        }
        Action = Disable;
    }

    private void Disable()
    {
        _image.texture = _icon1;
        foreach (Customization customization in _customizations)
        {
            customization.gameObject.SetActive(false);
        }

        _canvas.enabled = false;
        _customization = null;

        Action = Enable;
    }

    private void OpenDataSystem(Customization customization)
    {
        if(_customization != customization)
        {
            _canvas.enabled = true;
            _customization = customization;
            _addData.SetInputType(_customization.InputType);
        }
        else
        {
            _canvas.enabled = false;
            _customization = null;
        }
    }
}
