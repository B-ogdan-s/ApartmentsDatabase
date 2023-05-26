using API.Models;
using UnityEngine;
using UnityEngine.UI;


public class CastomizationPanel : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private Button _button;

    private MaterialResponce _materialResponce;
    private ModelResponce _modelResponce;

    private Texture2D _texture;
    private GameObject[] _obj;
    private int _id;

    public void Spawn(MaterialResponce request)
    {
        _materialResponce = request;

        SetIcon(request.imageUrl);

        _button.onClick.AddListener(SetMaterial);
    }
    public void Spawn(ModelResponce request)
    {
        _modelResponce = request;

        SetIcon(request.imageUrl);

        _button.onClick.AddListener(SetMesh);
    }

    public void SetObj(GameObject[] obj, int id)
    {
        _obj = obj;
        _id = id;
        Debug.Log(_obj.Length + ";  " + _id);
    }


    private void SetMaterial()
    {
        Debug.Log("Yes  1");
        Texture2D testTexture = new Texture2D(250, 250);
        testTexture.LoadImage(_materialResponce.materialUrl);

        foreach (var obj in _obj)
            obj.GetComponent<Renderer>().materials[_id].mainTexture = testTexture;

    }
    
    private void SetMesh()
    {
        Debug.Log("Yes  2");
        Texture2D testTexture = new Texture2D(250, 250);
        testTexture.LoadImage(_modelResponce.materialId);

        foreach (var obj in _obj)
            obj.GetComponent<Renderer>().materials[_id].mainTexture = testTexture;
    }

    private void SetIcon(byte[] texture)
    {
        Texture2D testTexture = new Texture2D(150, 150);
        testTexture.LoadImage(texture);
        _texture = testTexture;
        _image.texture = testTexture;
    }


    
}
