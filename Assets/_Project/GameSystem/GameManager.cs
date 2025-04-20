using Project.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.GameSystem
{
    public class GameManager : SingletonBase<GameManager>
    {
        #region Serialized Fields

        [SerializeField]
        private UnityEvent onGameStart;

        #endregion

        public event UnityAction OnGameStart
        {
            add => onGameStart?.AddListener(value);
            remove => onGameStart?.RemoveListener(value);
        }

        public void StartGame()
        {
            onGameStart?.Invoke();
        }
    }
}