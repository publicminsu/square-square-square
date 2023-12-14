using UnityEngine;

public class CubeObject : MonoBehaviour
{
    private Rigidbody cubeRigidbody;

    private void Awake()
    {
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        //구 위의 랜덤 좌표
        Vector3 targetVector = Random.onUnitSphere;

        //목표 좌표 바라보기
        Quaternion lookQuaternion = Quaternion.LookRotation(targetVector);
        transform.rotation = lookQuaternion;

        //이전의 속도 제거 후 목표 좌표로 힘 가하기
        cubeRigidbody.velocity = Vector3.zero;
        cubeRigidbody.AddForce(targetVector, ForceMode.VelocityChange);
    }
}
