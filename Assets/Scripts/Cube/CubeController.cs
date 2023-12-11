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
        StartStage();
    }
    private void StartStage()
    {
        for (int length = 0; length < 5; ++length)
        {
            for (int width = 0; width < 5; ++width)
            {
                for (int height = 0; height < 5; ++height)
                {
                    CubeObject cubeObject = cubeObjectPool.Get();

                    cubeObject.transform.localPosition = new(width, 20 + height, length);
                    StartCoroutine(cubeObject.Drop(height, 20 + height));
                }
            }
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
