using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    [SerializeField] private InputType _inputType;

    [SerializeField] private GameObject _object;

    public InputType InputType => _inputType;

    public event System.Action<Customization> OpenDatabase;

    public void Click()
    {
        OpenDatabase?.Invoke(this);
    }
}
