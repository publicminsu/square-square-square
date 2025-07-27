using UnityEngine;

namespace Project.UI
{
    public abstract class CanvasPresenterBase : MonoBehaviour
    {
        [SerializeField] protected Canvas canvas;

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