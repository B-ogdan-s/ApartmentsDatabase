using UnityEngine;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using TMPro;

public class AddData : MonoBehaviour
{
    [SerializeField] private InputMaterial _inputModelCanvas;
    [SerializeField] private InputMaterial _inputMaterialCanvas;

    private InputMaterial _openCanvas;

    public void Click()
    {
        _openCanvas.Open();

        /*
        FileUploaderHelper.RequestFile((path) =>
        {
            if (string.IsNullOrWhiteSpace(path))
                return;


            StartCoroutine(UploadImage(path));
        });
        */
    }

    public void SetInputType(InputType type)
    {
        switch(type)
        {
            case InputType.Material:
                _openCanvas = _inputMaterialCanvas;
                break;
            case InputType.Model:
                _openCanvas = _inputModelCanvas;
                break;
            default:
                Debug.LogError("Fack");
                break;

        }    
    }
}
