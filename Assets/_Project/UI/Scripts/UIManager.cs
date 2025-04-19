using Project.Utility;
using UnityEngine;

namespace Project.UI
{
    public class UIManager : SingletonBase<UIManager>
    {
        #region Serialized Fields

        [SerializeField]
        private CanvasPresenter mainMenuCanvasPresenter;

        [SerializeField]
        private CanvasPresenter gameplayCanvasPresenter;

        #endregion

        private CanvasPresenter _currentCanvasPresenter;

        public void ShowMainMenuCanvas()
        {
            HideCurrentCanvas();

            _currentCanvasPresenter = mainMenuCanvasPresenter;

            ShowCurrentCanvas();
        }

        public void ShowGameplayCanvas()
        {
            HideCurrentCanvas();

            _currentCanvasPresenter = gameplayCanvasPresenter;

            ShowCurrentCanvas();
        }

        private void HideCurrentCanvas()
        {
            _currentCanvasPresenter.Hide();
        }

        private void ShowCurrentCanvas()
        {
            _currentCanvasPresenter.Show();
        }
    }
}