using UnityEngine;

namespace Project.Input
{
    public class MouseInputController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private DeviceInput deviceInput;

        [SerializeField]
        private PlayerMover playerMover;

        #endregion

        private bool _isMouseClick;
        private bool _isMousePress;
        private Vector2 _nextDirection = Vector2.zero;
        private Vector2 _prevMousePosition;

        #region Event Functions

        private void Update()
        {
            if (_nextDirection == Vector2.zero) // 방향이 정해지지 않은 경우
            {
                return;
            }

            playerMover.Move(_nextDirection);

            _nextDirection = Vector2.zero;
        }

        private void OnEnable()
        {
            deviceInput.PositionPerformed += OnMousePositionChanged;
            deviceInput.PressPerformed += OnMousePressStarted;
            deviceInput.PressCanceled += OnMousePressEnded;
        }

        private void OnDisable()
        {
            deviceInput.PositionPerformed -= OnMousePositionChanged;
            deviceInput.PressPerformed -= OnMousePressStarted;
            deviceInput.PressCanceled -= OnMousePressEnded;
        }

        #endregion

        private void OnMousePressStarted()
        {
            _isMousePress = true;
            _isMouseClick = true;
        }

        private void OnMousePositionChanged(Vector2 mousePosition)
        {
            if (_isMousePress) //마우스를 누르고 있는 경우
            {
                _isMouseClick = false; //마우스를 움직이며 누르고 있다는 것은 클릭이 아니란 뜻

                //이전 마우스 위치에서 다음 마우스 위치의 방향을 구함
                var direction = mousePosition - _prevMousePosition;
                _nextDirection = direction.normalized;
            }

            _prevMousePosition = mousePosition;
        }

        private void OnMousePressEnded()
        {
            _isMousePress = false;
            _nextDirection = Vector2.zero;

            if (_isMouseClick) //만약 마우스를 누른 상태에서 움직이지 않았을 경우 = 클릭
            {
            }
        }
    }
}