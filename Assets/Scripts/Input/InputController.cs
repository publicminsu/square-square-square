using System;
using Project.Utility;
using UnityEngine;

namespace Project.Input
{
    public class InputController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Transform playerTransform;

        [SerializeField]
        private Transform cubeGroupTransform;

        #endregion

        private bool _isClick;
        private bool _isPress; //누르고 있는가?
        private Vector2 _nextDirection = Vector2.zero;

        private Vector2 _prevMovePosition, _prevUpdateMovePosition;

        private SphericalCoordinate _sphericalCoordinate;
        public Action InputEnded;
        public Action<Vector2> InputMoved;
        public Action InputStarted;

        #region Event Functions

        private void Start()
        {
            //초기 위치 설정
            _sphericalCoordinate = new SphericalCoordinate(10, -90, 90);
            playerTransform.position = _sphericalCoordinate.ToCartesianCoordinate();
        }

        private void Update()
        {
            if (_prevUpdateMovePosition == _prevMovePosition) //마우스를 계속 움직이지 않는 경우
            {
                return;
            }

            //다음 방향을 더해준 뒤 구면좌표계에서 3차원 데카르트 좌표를 구하여 대입함
            _sphericalCoordinate.AddDirectionDeg(_nextDirection * Time.deltaTime);
            playerTransform.position = _sphericalCoordinate.ToCartesianCoordinate();

            _prevUpdateMovePosition = _prevMovePosition;
        }

        private void LateUpdate()
        {
            //큐브 그룹의 중심을 바라보기
            var lookQuaternion =
                Quaternion.LookRotation((cubeGroupTransform.position - playerTransform.position).normalized);
            playerTransform.rotation = lookQuaternion;
        }

        private void OnEnable()
        {
            InputStarted += OnInputStarted;
            InputMoved += OnInputMoved;
            InputEnded += OnInputEnded;
        }

        private void OnDisable()
        {
            InputStarted -= OnInputStarted;
            InputMoved -= OnInputMoved;
            InputEnded -= OnInputEnded;
        }

        #endregion

        private void OnInputStarted()
        {
            _isPress = true;
            _isClick = true;
        }

        private void OnInputMoved(Vector2 movePosition)
        {
            if (_isPress) //마우스를 누르고 있는 경우
            {
                _isClick = false; //마우스를 움직이며 누르고 있다는 것은 클릭이 아니란 뜻

                //이전 마우스 위치에서 다음 마우스 위치의 방향을 구함
                var direction = movePosition - _prevMovePosition;
                _nextDirection = direction.normalized;

                _prevMovePosition = movePosition;
            }
        }

        private void OnInputEnded()
        {
            _isPress = false;
            _nextDirection = Vector2.zero;

            if (_isClick) //만약 마우스를 누른 상태에서 움직이지 않았을 경우 = 클릭
            {
            }
        }
    }
}