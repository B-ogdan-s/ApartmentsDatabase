using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotSpeed;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 direction)
    {
        Vector3 moveDirection = transform.forward * direction.y + transform.right * direction.x;

        _characterController.Move(moveDirection * _speed * Time.deltaTime);
    }
    public void Rotate(float direction)
    {
        transform.eulerAngles += Vector3.up * direction * _rotSpeed * Time.deltaTime;
    }
}
