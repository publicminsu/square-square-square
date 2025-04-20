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
            ShowCanvasInternal(mainMenuCanvasPresenter);
        }

        public void ShowGameplayCanvas()
        {
            ShowCanvasInternal(gameplayCanvasPresenter);
        }

        private void ShowCanvasInternal(CanvasPresenter targetCanvasPresenter)
        {
            _currentCanvasPresenter.Hide();

            _currentCanvasPresenter = targetCanvasPresenter;

            _currentCanvasPresenter.Show();
        }
    }
}