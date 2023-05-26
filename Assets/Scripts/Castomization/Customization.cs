using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    [SerializeField] private InputType _inputType;

    [SerializeField] private GameObject[] _object;
    [SerializeField] private int _materialID;

    public InputType InputType => _inputType;

    public event System.Action<Customization> OpenDatabase;
    public event System.Action<GameObject[], int> GetObject;

    public void Click()
    {
        GetObject?.Invoke(_object, _materialID);
        OpenDatabase?.Invoke(this);
    }
}
