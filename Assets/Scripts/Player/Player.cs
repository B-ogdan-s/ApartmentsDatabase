using UnityEngine;
using InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputButton _inputButton;
        [SerializeField] private InputClick _inputClick;

        private PlayerMove _playerMove;
        private Camera _camera;

        private void Start()
        {
            _inputButton.SetDirection += Move;
            _inputClick.SetVerticalDirection += VerticalRot;
            _inputClick.SetHorizontalDirection += HorizontalRot;

            _camera = GetComponentInChildren<Camera>();
            _playerMove = GetComponent<PlayerMove>();
        }

        private void Move(Vector2 direction)
        {
            if (direction != Vector2.zero)
                _playerMove.Move(direction);
        }
        private void VerticalRot(float direction)
        {
            _camera.RotCamera(direction);
        }
        private void HorizontalRot(float direction)
        {
            _playerMove.Rotate(direction);
        }

        private void OnDestroy()
        {
            _inputButton.SetDirection -= Move;
            _inputClick.SetVerticalDirection -= VerticalRot;
            _inputClick.SetHorizontalDirection -= HorizontalRot;
        }

    }
}
