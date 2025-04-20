using System.Collections;
using _Project.GameSystem;
using Project.GameTime;
using Project.Score;
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
        private ScoreData scoreData;

        [SerializeField]
        private GameTimeData gameTimeData;

        #endregion

        private CubeObjectPool _cubeObjectPool;

        #region Event Functions

        private void Awake()
        {
            _cubeObjectPool = new CubeObjectPool(cubeObjectPrefab, cubeGroupTransform);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStart += StartGame;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameStart -= StartGame;
        }

        #endregion

        private void StartGame()
        {
            scoreData.InitScore();
            gameTimeData.InitTime();

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

                gameTimeData.IncreaseTime();
                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}