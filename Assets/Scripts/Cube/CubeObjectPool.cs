using UnityEngine;
using UnityEngine.Pool;

namespace Project.Cube
{
    /// <summary>
    ///     CubeObject를 위한 ObjectPool
    /// </summary>
    public class CubeObjectPool
    {
        private readonly Transform _cubeGroupTransform;
        private readonly GameObject _cubeObjectPrefab;

        /// <summary>
        ///     큐브 프리팹을 생성할 때 사용할 값을 받는 생성자
        /// </summary>
        /// <param name="cubeObjectPrefab">생성할 큐브 프리팹</param>
        /// <param name="cubeGroupTransform">생성할 큐브 프리팹 부모의 transform</param>
        public CubeObjectPool(GameObject cubeObjectPrefab, Transform cubeGroupTransform)
        {
            _cubeObjectPrefab = cubeObjectPrefab;
            _cubeGroupTransform = cubeGroupTransform;

            Pool = new ObjectPool<CubeObject>(CreateCubeObject, OnGetCube, OnReleaseCube, OnDestroyCube);
        }

        /// <summary>
        ///     외부에서 접근 가능한 오브젝트풀
        /// </summary>
        public ObjectPool<CubeObject> Pool { get; private set; }

        /// <summary>
        ///     큐브 프리팹을 생성 후 CubeObject를 반환
        /// </summary>
        /// <returns>프리팹에서 가져온 CubeObject 컴포넌트</returns>
        private CubeObject CreateCubeObject()
        {
            var cubeGameObject = Object.Instantiate(_cubeObjectPrefab, _cubeGroupTransform);

            var cubeObject = cubeGameObject.GetComponent<CubeObject>();

            return cubeObject;
        }

        /// <summary>
        ///     큐브를 풀에서 가져올 때 활성화
        /// </summary>
        /// <param name="cubeObject">가져오는 큐브</param>
        private void OnGetCube(CubeObject cubeObject)
        {
            cubeObject.gameObject.SetActive(true);
        }

        /// <summary>
        ///     큐브를 풀에 반환할 때 비활성화
        /// </summary>
        /// <param name="cubeObject">반환하는 큐브</param>
        private void OnReleaseCube(CubeObject cubeObject)
        {
            cubeObject.gameObject.SetActive(false);
        }

        /// <summary>
        ///     큐브를 파괴
        /// </summary>
        /// <param name="cubeObject">파괴활 큐브</param>
        private void OnDestroyCube(CubeObject cubeObject)
        {
            Object.Destroy(cubeObject);
        }
    }
}