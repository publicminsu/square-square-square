using System.Collections;
using Project.Data;
using UnityEngine;

namespace Project.Cube
{
    public class CubeController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private GameObject cubeObjectPrefab;

        [SerializeField]
        private Transform cubeGroupTransform;

        [SerializeField]
        private ScoreDataSO scoreData;

        [SerializeField]
        private TimeDataSO timeData;

        #endregion

        private CubeObjectPool _cubeObjectPool;

        #region Event Functions

        private void Awake()
        {
            _cubeObjectPool = new CubeObjectPool(cubeObjectPrefab, cubeGroupTransform);
        }

        private void Start()
        {
            StartGame();
        }

        #endregion

        public void StartGame()
        {
            scoreData.InitScore();
            timeData.InitTime();

            StartCoroutine(UpdateGame());
        }

        private IEnumerator UpdateGame()
        {
            var currentTime = 0f;

            while (true)
            {
                if (currentTime >= 1f)
                {
                    var cubeObject = _cubeObjectPool.Pool.Get();
                    cubeObject.Shoot();
                    currentTime = 0f;
                }

                timeData.IncreaseTime();
                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}