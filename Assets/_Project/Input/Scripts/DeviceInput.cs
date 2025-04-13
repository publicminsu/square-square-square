using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    public class DeviceInput : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        #region Event Functions

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            var playerActions = _playerInputActions.Player;
            playerActions.Enable();

            playerActions.Position.performed += OnPositionPerformed;

            playerActions.Press.performed += OnPressPerformed;
            playerActions.Press.canceled += OnPressCanceled;

            playerActions.Move.performed += OnMovePerformed;
            playerActions.Move.canceled += OnMoveCanceled;
        }

        private void OnDisable()
        {
            var playerActions = _playerInputActions.Player;
            playerActions.Disable();

            playerActions.Position.performed -= OnPositionPerformed;

            playerActions.Press.performed -= OnPressPerformed;
            playerActions.Press.canceled -= OnPressCanceled;

            playerActions.Move.performed -= OnMovePerformed;
            playerActions.Move.canceled -= OnMoveCanceled;
        }

        #endregion

        public event Action<Vector2> PositionPerformed;
        public event Action PressPerformed;
        public event Action PressCanceled;
        public event Action<Vector2> MovePerformed;
        public event Action MoveCanceled;

        private void OnPositionPerformed(InputAction.CallbackContext callbackContext)
        {
            var position = callbackContext.ReadValue<Vector2>();
            PositionPerformed?.Invoke(position);
        }

        private void OnPressPerformed(InputAction.CallbackContext callbackContext)
        {
            PressPerformed?.Invoke();
        }

        private void OnPressCanceled(InputAction.CallbackContext callbackContext)
        {
            PressCanceled?.Invoke();
        }

        private void OnMovePerformed(InputAction.CallbackContext callbackContext)
        {
            MovePerformed?.Invoke(callbackContext.ReadValue<Vector2>());
        }

        private void OnMoveCanceled(InputAction.CallbackContext callbackContext)
        {
            MoveCanceled?.Invoke();
        }
    }
}