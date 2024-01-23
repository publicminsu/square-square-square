using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CubeController : MonoBehaviour
{
    private ObjectPool<CubeObject> cubeObjectPool;
    [SerializeField] GameObject cubeObjectPrefab;

    [SerializeField] private Transform cubeGroupTransform;

    private void Awake()
    {
        cubeObjectPool = new ObjectPool<CubeObject>(CreateCubeObject, OnGetCube, OnReleaseCube, OnDestroyCube);
    }
    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        WaitForSeconds waitForSeconds = new(1f);

        while (true)
        {
            CubeObject cubeObject = cubeObjectPool.Get();
            cubeObject.Shoot();
            yield return waitForSeconds;
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
