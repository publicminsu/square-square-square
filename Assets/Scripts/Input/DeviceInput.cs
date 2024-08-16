using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    public class DeviceInput : MonoBehaviour
    {
        private InputController _inputController;

        private Vector2 _position;

        #region Event Functions

        private void Awake()
        {
            _inputController = GetComponent<InputController>();
        }

        #endregion

        public void OnPosition(InputAction.CallbackContext callbackContext)
        {
            _position = callbackContext.ReadValue<Vector2>();
            _inputController.InputMoved(_position);
        }

        public void OnPress(InputAction.CallbackContext callbackContext)
        {
            switch (callbackContext.phase)
            {
                case InputActionPhase.Performed: //시작
                    _inputController.InputStarted();
                    break;

                case InputActionPhase.Canceled: //중지
                    _inputController.InputEnded();
                    break;
            }
        }
    }
}