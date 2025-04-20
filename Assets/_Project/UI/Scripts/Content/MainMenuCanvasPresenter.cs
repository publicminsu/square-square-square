using _Project.GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI.Content
{
    public class MainMenuCanvasPresenter : CanvasPresenterBase<MainMenuCanvasPresenter>
    {
        #region Serialized Fields

        [SerializeField]
        private Button gameStartButton;

        #endregion

        #region Event Functions

        private void Start()
        {
            UIManager.Instance.ShowCanvas<MainMenuCanvasPresenter>();
        }

        #endregion

        protected override void OnRegister()
        {
            gameStartButton.onClick.AddListener(StartGame);
        }

        protected override void OnUnregister()
        {
            gameStartButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            GameManager.Instance.StartGame();
        }
    }
}