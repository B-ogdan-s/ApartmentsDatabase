using System;
using UnityEngine;

namespace InputSystem
{
    public class InputButton : MonoBehaviour
    {
        [SerializeField] private ButtonInfo[] buttonInfos;

        public event Action<Vector2> SetDirection;

        private void Update()
        {
            Vector2 direction = Vector2.zero;
            foreach(var buttonInfo in buttonInfos)
            {
                if(Input.GetKey(buttonInfo.Key))
                {
                    direction += buttonInfo.Direction;
                }
            }

            SetDirection?.Invoke(direction.normalized);
        }
    }

    [Serializable]
    public class ButtonInfo
    {
        [SerializeField] private KeyCode _key;
        [SerializeField] private Vector2 _direction;

        public KeyCode Key => _key;
        public Vector2 Direction => _direction;
    }
}