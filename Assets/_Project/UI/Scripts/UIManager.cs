using System;
using System.Collections.Generic;
using Project.Utility;
using UnityEngine;

namespace Project.UI
{
    public class UIManager : SingletonBase<UIManager>
    {
        private readonly Dictionary<Type, CanvasPresenter> _canvasPresenters = new();

        private CanvasPresenter _currentCanvasPresenter;

        public void Register<T>(T presenter) where T : CanvasPresenter
        {
            _canvasPresenters[typeof(T)] = presenter;
        }

        public void Unregister<T>() where T : CanvasPresenter
        {
            _canvasPresenters.Remove(typeof(T));
        }

        public void ShowCanvas<T>() where T : CanvasPresenter
        {
            var type = typeof(T);

            if (_canvasPresenters.TryGetValue(type, out var targetCanvasPresenter))
            {
                if (_currentCanvasPresenter)
                {
                    _currentCanvasPresenter.Hide();
                }

                _currentCanvasPresenter = targetCanvasPresenter;

                _currentCanvasPresenter.Show();
            }
            else
            {
                Debug.LogWarning($"[{nameof(UIManager)}] {type}을 사용하는 {nameof(CanvasPresenter)}를 찾을 수 업습니다.", this);
            }
        }
    }
}