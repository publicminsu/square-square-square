using UnityEngine;

namespace Project.Input
{
    public class KeyboardInputController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private DeviceInput deviceInput;

        [SerializeField]
        private PlayerMover playerMover;

        #endregion

        private bool _isKeyboardPress;

        private Vector2 _nextDirection = Vector2.zero;

        #region Event Functions

        private void Update()
        {
            if (_isKeyboardPress)
            {
                playerMover.Move(_nextDirection);
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

        //TODO : 키보드 스페이스로 클릭을 구현
    }
}