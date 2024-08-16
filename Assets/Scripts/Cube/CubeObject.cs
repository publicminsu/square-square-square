using Project.Data;
using UnityEngine;

namespace Project.Cube
{
    public class CubeObject : MonoBehaviour
    {
        private Rigidbody cubeRigidbody;

        [SerializeField]
        private ScoreDataSO scoreData;

        private void Awake()
        {
            cubeRigidbody = GetComponent<Rigidbody>();
        }

        public void Shoot()
        {
            //구 위의 랜덤 좌표
            Vector3 targetVector = Random.onUnitSphere;

            //목표 방향 바라보기
            Quaternion lookQuaternion = Quaternion.LookRotation(targetVector);
            transform.rotation = lookQuaternion;

            //목표 방향으로 속도 설정
            cubeRigidbody.velocity = targetVector;
        }

        private void OnTriggerExit(Collider other)
        {
            transform.position = Vector3.zero;
            Shoot();
            scoreData.IncreaseScore();
        }
    }
}