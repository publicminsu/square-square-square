using UnityEngine;

namespace Project.Input
{
    public class KeyboardInputController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private DeviceInput deviceInput;

        [SerializeField]
        private Transform playerTransform;

        #endregion

        private bool _isKeyboardPress;

        private Vector2 _nextDirection = Vector2.zero;

        #region Event Functions

        private void Update()
        {
            if (_isKeyboardPress)
            {
                MouseInputController.SphericalCoordinate.AddDirectionDeg(_nextDirection * Time.deltaTime);
                playerTransform.position = MouseInputController.SphericalCoordinate.ToCartesianCoordinate();
            }
        }

        private void OnEnable()
        {
            deviceInput.MovePerformed += OnKeyboardMoveStarted;
            deviceInput.MoveCanceled += OnKeyboardMoveEnded;
        }

        private void OnDisable()
        {
            deviceInput.MovePerformed -= OnKeyboardMoveStarted;
            deviceInput.MoveCanceled -= OnKeyboardMoveEnded;
        }

        #endregion

        private void OnKeyboardMoveStarted(Vector2 value)
        {
            _isKeyboardPress = true;
            _nextDirection = value.normalized;
        }

        private void OnKeyboardMoveEnded()
        {
            _isKeyboardPress = false;
        }
    }
}