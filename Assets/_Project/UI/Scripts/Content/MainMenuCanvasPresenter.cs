using _Project.GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI.Content
{
    public class MainMenuCanvasPresenter : CanvasPresenterBase
    {
        [SerializeField] private Button gameStartButton;

        private void OnEnable()
        {
            gameStartButton.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            gameStartButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            GameManager.Instance.StartGame();
        }
    }
}