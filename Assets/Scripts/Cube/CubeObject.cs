using Project.Data;
using UnityEngine;

namespace Project.Cube
{
    public class CubeObject : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private ScoreDataSO scoreData;

        #endregion

        private Rigidbody _cubeRigidbody;

        #region Event Functions

        private void Awake()
        {
            _cubeRigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerExit(Collider other)
        {
            transform.position = Vector3.zero;
            Shoot();
            scoreData.IncreaseScore();
        }

        #endregion

        public void Shoot()
        {
            //구 위의 랜덤 좌표
            var targetVector = Random.onUnitSphere;

            //목표 방향 바라보기
            var lookQuaternion = Quaternion.LookRotation(targetVector);
            transform.rotation = lookQuaternion;

            //목표 방향으로 속도 설정
            _cubeRigidbody.velocity = targetVector;
        }
    }
}