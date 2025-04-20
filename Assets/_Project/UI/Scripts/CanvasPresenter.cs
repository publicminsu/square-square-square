using UnityEngine;

namespace Project.UI
{
    /// <summary>
    ///     UIManager에 등록/해제하는 과정을 위해 CanvasPresenterBase<![CDATA[<T>]]>을 사용해야 합니다.
    /// </summary>
    public abstract class CanvasPresenter : MonoBehaviour
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