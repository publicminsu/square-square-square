using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Action InputStartEvent;
    public Action<Vector2> InputMoveEvent;
    public Action InputEndEvent;

    private Vector2 prevMovePosition, prevUpdateMovePosition;
    private Vector2 nextDirection = Vector2.zero;

    private bool isPress = false;//누르고 있는가?
    private bool isClick;

    private SphericalCoordinate sphericalCoordinate;
    [SerializeField] private Transform cubeGroupTransform;

    private void Start()
    {
        InputStartEvent += OnInputStart;
        InputMoveEvent += OnInputMove;
        InputEndEvent += OnInputEnd;

        //초기 위치 설정
        sphericalCoordinate = new(10, -90, 90);
        transform.position = sphericalCoordinate.ToCartesianCoordinate();
    }

    private void Update()
    {
        if (prevUpdateMovePosition == prevMovePosition)//마우스를 계속 움직이지 않는 경우
        {
            return;
        }

        //다음 방향을 더해준 뒤 구면 좌표계에서의 좌표를 구하여 대입함
        sphericalCoordinate.AddDirectionDeg(nextDirection);
        transform.position = sphericalCoordinate.ToCartesianCoordinate();

        prevUpdateMovePosition = prevMovePosition;
    }

    private void LateUpdate()
    {
        //큐브 그룹의 중심을 바라보기
        Quaternion lookQuaternion = Quaternion.LookRotation((cubeGroupTransform.position - transform.position).normalized);
        transform.rotation = lookQuaternion;
    }

    private void OnInputStart()
    {
        isPress = true;
        isClick = true;
    }
    private void OnInputMove(Vector2 movePosition)
    {
        if (isPress)//마우스를 누르고 있는 경우
        {
            isClick = false;//마우스를 움직이며 누르고 있다는 것은 클릭이 아니란 뜻

            //이전 마우스 위치에서 다음 마우스 위치의 방향을 구함
            Vector2 direction = movePosition - prevMovePosition;
            nextDirection = direction.normalized;

            prevMovePosition = movePosition;
        }
        else
        {

        }
    }
    private void OnInputEnd()
    {
        isPress = false;
        nextDirection = Vector2.zero;

        if (isClick)//만약 마우스를 누른 상태에서 움직이지 않았을 경우 = 클릭
        {

        }
    }
}
