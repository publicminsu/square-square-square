using System;
using System.Collections.Generic;
using Project.Utility;
using UnityEngine;

namespace Project.UI
{
    public class UIManager : SingletonBase<UIManager>
    {
        [Serializable]
        public class UICanvasConfig
        {
            [field: SerializeField] public UICanvasType UICanvasType { get; private set; }

            [field: SerializeField] public CanvasPresenterBase CanvasPresenterPrefab { get; private set; }
        }

        [SerializeField] private Canvas rootCanvas;

        [SerializeField] private UICanvasType initialCanvasType;

        [SerializeField] private List<UICanvasConfig> uiCanvasConfigs;

        private readonly Dictionary<UICanvasType, CanvasPresenterBase> _canvasPresenters = new();

        private CanvasPresenterBase _currentCanvasPresenter;

        private void Start()
        {
            foreach (var config in uiCanvasConfigs)
            {
                var ui = Instantiate(config.CanvasPresenterPrefab, rootCanvas.transform);
                _canvasPresenters.Add(config.UICanvasType, ui);

                if (config.UICanvasType != initialCanvasType)
                    ui.Hide();
                else
                    _currentCanvasPresenter = ui;
            }
        }


        public void ShowCanvas(UICanvasType uiCanvasType)
        {
            if (_canvasPresenters.TryGetValue(uiCanvasType, out var targetCanvasPresenter))
            {
                if (_currentCanvasPresenter) _currentCanvasPresenter.Hide();

                _currentCanvasPresenter = targetCanvasPresenter;

                _currentCanvasPresenter.Show();
            }
            else
            {
                Debug.LogError($"[{nameof(UIManager)}] {uiCanvasType}을 사용하는 {nameof(CanvasPresenterBase)}를 찾을 수 업습니다.",
                    this);
            }
        }
    }
}