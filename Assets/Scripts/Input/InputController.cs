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

    private Camera mainCamera;

    private SphericalCoordinate sphericalCoordinate;
    [SerializeField] private Transform cubeGroupTransform;

    private void Start()
    {
        mainCamera = Camera.main;

        InputStartEvent += OnInputStart;
        InputMoveEvent += OnInputMove;
        InputEndEvent += OnInputEnd;

        sphericalCoordinate = new(10, -90, 90);
        transform.position = sphericalCoordinate.ToCartesianCoordinate() + Vector3.one * 2.5f;
    }

    private void FixedUpdate()
    {
        if (prevUpdateMovePosition == prevMovePosition)
        {
            return;
        }
        sphericalCoordinate.AddDirectionDeg(nextDirection);
        transform.position = sphericalCoordinate.ToCartesianCoordinate() + Vector3.one * 2.5f;

        prevUpdateMovePosition = prevMovePosition;
    }

    private void LateUpdate()
    {
        Quaternion lookQuaternion = Quaternion.LookRotation(((cubeGroupTransform.position + Vector3.one * 2.5f) - transform.position).normalized);
        transform.rotation = lookQuaternion;
    }

    private void OnInputStart()
    {
        isPress = true;
        isClick = true;
    }
    private void OnInputMove(Vector2 movePosition)
    {
        if (isPress)
        {
            isClick = false;
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
        if (isClick)
        {

        }
    }
}
