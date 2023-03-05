using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private float _maxRotl;
        [SerializeField] private float _minRotl;

        private float rot = 0;

        public void RotCamera(float direction)
        {
            float newRot = rot + direction * _speed * Time.deltaTime;


            if (newRot > _minRotl && newRot < _maxRotl)
            {
                rot = newRot;
                transform.localEulerAngles = Vector3.right * newRot;
            }
        }
    }
}
