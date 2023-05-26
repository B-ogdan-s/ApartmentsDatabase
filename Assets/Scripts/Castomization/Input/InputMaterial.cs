using API.Models;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InputMaterial : MonoBehaviour
{
    [SerializeField] protected CastomizationList _customization;
    [SerializeField] private Texture2D _standartTexture;
    [SerializeField] private RawImage _icon;

    [SerializeField] private Image _trueMaterialImage;
    [SerializeField] private Image _falseMaterialImage;

    protected byte[] _texture;
    protected byte[] _materialTexture;


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
        _trueMaterialImage.enabled = false;
        _falseMaterialImage.enabled = false;
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
                _trueMaterialImage.enabled = false;
                _falseMaterialImage.enabled = true;
                return;
            }

            _trueMaterialImage.enabled = true;
            _falseMaterialImage.enabled = false;

            StartCoroutine(UploadMaterial(path));

        }, ".png");
    }


    IEnumerator UploadImage(string path)
    {
        UnityWebRequest fileLoader = UnityWebRequest.Get(path);
        yield return fileLoader.SendWebRequest();

        byte[] bytes = fileLoader.downloadHandler.data;

        Texture2D testTexture = new Texture2D(150, 150);
        testTexture.LoadImage(bytes);
        _icon.texture = testTexture;
        _texture = bytes; // Encoding.Default.GetString(bytes);
    }
    IEnumerator UploadMaterial(string path)
    {
        UnityWebRequest fileLoader = UnityWebRequest.Get(path);
        yield return fileLoader.SendWebRequest();

        byte[] bytes = fileLoader.downloadHandler.data;

        _materialTexture = bytes; // Encoding.Default.GetString(bytes);
    }

    public virtual void Save()
    {
        Close();
        /*
        if (string.IsNullOrEmpty(_texture) || string.IsNullOrEmpty(_materialTexture))
        {
            Debug.Log("fail");
            return;
        }
        */

        MaterialRequest materialRequest = new MaterialRequest()
        {
            imageUrl = _texture,
            materialUrl = _materialTexture
        };

        Debug.Log("imageUrl: " + _texture);
        Debug.Log("materialUrl: " + _materialTexture);

        Api.Instance.SendRequest("https://test-server-1w9i.onrender.com/addmaterial", Api.RequestType.POST, materialRequest);

        _customization.UpdateCustomization(InputType.Material);
    }
}
