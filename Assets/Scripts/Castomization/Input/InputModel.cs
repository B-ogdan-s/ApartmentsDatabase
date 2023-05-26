using API.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InputModel : InputMaterial
{
    [SerializeField] private Image _trueModelImage;
    [SerializeField] private Image _falseModelImage;

    protected byte[] _modelPath;

    protected override void Clear()
    {
        base.Clear();
        _trueModelImage.enabled = false;
        _falseModelImage.enabled = false;
    }

    public void InputModelData()
    {
        FileUploaderHelper.RequestFile((path) =>
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                _trueModelImage.enabled = false;
                _falseModelImage.enabled = true;
                return;
            }

            _trueModelImage.enabled = true;
            _falseModelImage.enabled = false;

            StartCoroutine(UploadModel(path));

        }, ".fbx");
    }
    IEnumerator UploadModel(string path)
    {
        UnityWebRequest fileLoader = UnityWebRequest.Get(path);
        yield return fileLoader.SendWebRequest();

        byte[] bytes = fileLoader.downloadHandler.data;

        _modelPath = bytes;
    }

    public override void Save()
    {
        Close();
        /*

        if (string.IsNullOrEmpty(_texture) || string.IsNullOrEmpty(_materialTexture))
        {
            Debug.Log("fail");
            return;
        }

        */
        ModelRequest modelRequest = new ModelRequest()
        {
            imageUrl = _texture,
            materialId= _materialTexture,
            objectUrl = _modelPath
            
        };

        Debug.Log("imageUrl: " + _texture);
        Debug.Log("materialUrl: " + _materialTexture);
        Debug.Log("modelUrl: " + _modelPath);

        Api.Instance.SendRequest("https://test-server-1w9i.onrender.com/addmodel", Api.RequestType.POST, modelRequest);

        _customization.UpdateCustomization(InputType.Model);
    }
}
