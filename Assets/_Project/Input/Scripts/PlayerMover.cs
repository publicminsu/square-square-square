using Project.Utility;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform cubeGroupTransform; //TODO : 리지드바디로 수정

    #endregion

    private SphericalCoordinate _sphericalCoordinate;

    #region Event Functions

    private void Start()
    {
        //초기 위치 설정
        _sphericalCoordinate = new SphericalCoordinate(10, -90, 90);
        playerTransform.position = _sphericalCoordinate.ToCartesianCoordinate();
    }

    private void LateUpdate()
    {
        var direction = cubeGroupTransform.position - playerTransform.position;
        var lookQuaternion = Quaternion.LookRotation(direction.normalized);
        playerTransform.rotation = lookQuaternion;
    }

    #endregion

    /// <summary>
    ///     플레이어를 이동시킵니다.
    /// </summary>
    /// <param name="direction">이동할 방향</param>
    internal void Move(Vector2 direction)
    {
        _sphericalCoordinate.AddDirectionDeg(direction * Time.deltaTime);
        playerTransform.position = _sphericalCoordinate.ToCartesianCoordinate();
    }
}