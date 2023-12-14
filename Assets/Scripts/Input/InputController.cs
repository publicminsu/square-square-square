using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Action InputStartEvent;
    public Action<Vector2> InputMoveEvent;
    public Action InputEndEvent;

    private Vector2 prevMovePosition, prevUpdateMovePosition;
    private Vector2 nextDirection = Vector2.zero;

    private bool isPress = false;//������ �ִ°�?
    private bool isClick;

    private SphericalCoordinate sphericalCoordinate;
    [SerializeField] private Transform cubeGroupTransform;

    private void Start()
    {
        InputStartEvent += OnInputStart;
        InputMoveEvent += OnInputMove;
        InputEndEvent += OnInputEnd;

        //�ʱ� ��ġ ����
        sphericalCoordinate = new(10, -90, 90);
        transform.position = sphericalCoordinate.ToCartesianCoordinate();
    }

    private void Update()
    {
        if (prevUpdateMovePosition == prevMovePosition)//���콺�� ��� �������� �ʴ� ���
        {
            return;
        }

        //���� ������ ������ �� ���� ��ǥ�迡���� ��ǥ�� ���Ͽ� ������
        sphericalCoordinate.AddDirectionDeg(nextDirection);
        transform.position = sphericalCoordinate.ToCartesianCoordinate();

        prevUpdateMovePosition = prevMovePosition;
    }

    private void LateUpdate()
    {
        //ť�� �׷��� �߽��� �ٶ󺸱�
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
        if (isPress)//���콺�� ������ �ִ� ���
        {
            isClick = false;//���콺�� �����̸� ������ �ִٴ� ���� Ŭ���� �ƴ϶� ��

            //���� ���콺 ��ġ���� ���� ���콺 ��ġ�� ������ ����
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

        if (isClick)//���� ���콺�� ���� ���¿��� �������� �ʾ��� ��� = Ŭ��
        {

        }
    }
}
