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
        //�� ���� ���� ��ǥ
        Vector3 targetVector = Random.onUnitSphere;

        //��ǥ ���� �ٶ󺸱�
        Quaternion lookQuaternion = Quaternion.LookRotation(targetVector);
        transform.rotation = lookQuaternion;

        //��ǥ �������� �ӵ� ����
        cubeRigidbody.velocity = targetVector;
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position= Vector3.zero;
        Shoot();
    }
}
