namespace Project.UI.Content
{
    public abstract class CanvasPresenterBase<T> : CanvasPresenter where T : CanvasPresenterBase<T>
    {
        #region Event Functions

        private void OnEnable()
        {
            UIManager.Instance.Register(this as T);
            OnRegister();
        }

        private void OnDisable()
        {
            UIManager.Instance.Unregister<T>();
            OnUnregister();
        }

        #endregion

        protected virtual void OnRegister()
        {
        }

        protected virtual void OnUnregister()
        {
        }
    }
}