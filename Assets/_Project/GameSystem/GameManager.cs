using System;
using Project.Utility;

namespace _Project.GameSystem
{
    public class GameManager : SingletonBase<GameManager>
    {
        public static event Action OnGameStart;

        public void StartGame()
        {
            OnGameStart?.Invoke();
        }
    }
}