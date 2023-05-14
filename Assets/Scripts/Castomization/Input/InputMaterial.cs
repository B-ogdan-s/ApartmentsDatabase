using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InputMaterial : MonoBehaviour
{
    [SerializeField] private Texture2D _standartTexture;
    [SerializeField] private RawImage _icon;

    [SerializeField] private Texture2D _texture;
    [SerializeField] private Material _material;


    private Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    public void Open()
    {
        _canvas.enabled = true;
    }

    public void Close()
    {
        _canvas.enabled = false;
        Clear();
    }
    protected virtual void Clear()
    {
        _icon.texture = _standartTexture;
    }

    public void InputIcon()
    {
        FileUploaderHelper.RequestFile((path) =>
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                _icon.texture = _standartTexture;
                return;
            }

            StartCoroutine(UploadImage(path));

        }, ".png");
    }

    public void InputMaterialData()
    {
        FileUploaderHelper.RequestFile((path) =>
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            StartCoroutine(UploadMaterial(path));

        }, ".mat");
    }


    IEnumerator UploadImage(string path)
    {
        UnityWebRequest fileLoader = UnityWebRequest.Get(path);
        yield return fileLoader.SendWebRequest();

        byte[] bytes = fileLoader.downloadHandler.data;

        Texture2D testText = new Texture2D(250, 250);
        testText.LoadImage(bytes);
        _icon.texture = testText;
    }
    IEnumerator UploadMaterial(string path)
    {
        UnityWebRequest fileLoader = UnityWebRequest.Get(path);
        yield return fileLoader.SendWebRequest();

        byte[] bytes = fileLoader.downloadHandler.data;

        Material newMaterial;
    }
}
