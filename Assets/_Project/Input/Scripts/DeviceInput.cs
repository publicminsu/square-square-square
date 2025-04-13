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

            playerActions.Position.performed += Position_Performed;

            playerActions.Press.performed += Press_Performed;
            playerActions.Press.canceled += Press_Canceled;
        }

        private void OnDisable()
        {
            var playerActions = _playerInputActions.Player;
            playerActions.Enable();

            playerActions.Position.performed -= Position_Performed;

            playerActions.Press.performed -= Press_Performed;
            playerActions.Press.canceled -= Press_Canceled;
        }

        #endregion

        public event Action<Vector2> PositionPerformed;
        public event Action PressPerformed;
        public event Action PressCanceled;

        private void Position_Performed(InputAction.CallbackContext callbackContext)
        {
            var position = callbackContext.ReadValue<Vector2>();
            PositionPerformed?.Invoke(position);
        }

        private void Press_Performed(InputAction.CallbackContext callbackContext)
        {
            PressPerformed?.Invoke();
        }

        private void Press_Canceled(InputAction.CallbackContext callbackContext)
        {
            PressCanceled?.Invoke();
        }
    }
}