using UnityEngine;

namespace Project.UI
{
    public class CanvasPresenter : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        protected Canvas canvas;

        #endregion

        public void Show()
        {
            canvas.enabled = true;
        }

        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}