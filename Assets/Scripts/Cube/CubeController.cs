using System.Collections;
using Project.Data;
using UnityEngine;
using UnityEngine.Pool;

namespace Project.Cube
{
    public class CubeController : MonoBehaviour
    {
        private ObjectPool<CubeObject> _cubeObjectPool;

        [SerializeField]
        private GameObject cubeObjectPrefab;

        [SerializeField]
        private Transform cubeGroupTransform;

        [SerializeField]
        private ScoreDataSO scoreData;
        
        [SerializeField]
        private TimeDataSO timeData;

        private void Awake()
        {
            _cubeObjectPool = new ObjectPool<CubeObject>(CreateCubeObject, OnGetCube, OnReleaseCube, OnDestroyCube);
        }

        private void Start()
        {
            StartCoroutine(StartGame());
        }

        private IEnumerator StartGame()
        {
            scoreData.InitScore();
            timeData.InitTime();

            float currentTime = 0f;

            while (true)
            {
                if (currentTime >= 1f)
                {
                    CubeObject cubeObject = _cubeObjectPool.Get();
                    cubeObject.Shoot();
                    currentTime = 0f;
                }

                timeData.IncreaseTime();
                currentTime += Time.deltaTime;
                yield return null;
            }
        }

        #region Cube Object Pool

        private CubeObject CreateCubeObject()
        {
            GameObject cubeGameObject = Instantiate(cubeObjectPrefab, cubeGroupTransform);

            CubeObject cubeObject = cubeGameObject.GetComponent<CubeObject>();

            return cubeObject;
        }

        private void OnGetCube(CubeObject cubeObject)
        {
            cubeObject.gameObject.SetActive(true);
        }

        private void OnReleaseCube(CubeObject cubeObject)
        {
            cubeObject.gameObject.SetActive(false);
        }

        private void OnDestroyCube(CubeObject cubeObject)
        {
            Destroy(cubeObject);
        }

        #endregion
    }
}