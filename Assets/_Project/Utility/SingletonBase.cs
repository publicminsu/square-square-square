using UnityEngine;

namespace Project.Utility
{
    public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                Init();
                return _instance;
            }
        }

        #region Event Functions

        private void Awake()
        {
            Init();
        }

        #endregion

        private static void Init()
        {
            if (_instance)
            {
                return;
            }

            const string gameManagerInstanceName = "GameManager";

            var gameManagerInstance = GameObject.Find(gameManagerInstanceName);

            if (!gameManagerInstance)
            {
                gameManagerInstance = new GameObject(gameManagerInstanceName);
                DontDestroyOnLoad(gameManagerInstance);
            }

            if (!gameManagerInstance.TryGetComponent(out _instance))
            {
                _instance = gameManagerInstance.AddComponent<T>();
            }
        }
    }
}