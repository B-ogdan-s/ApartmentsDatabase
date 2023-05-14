using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRot : MonoBehaviour
{
    private Transform _cameraPos;
    private void Awake()
    {
        _cameraPos = Camera.main.transform;
    }


    private void Update()
    {
        transform.LookAt(_cameraPos.position);
    }
}
