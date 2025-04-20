using System.Text;
using _Project.GameSystem;
using Project.GameTime;
using Project.Score;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.UI.Content
{
    public class GameplayCanvasPresenter : CanvasPresenterBase<GameplayCanvasPresenter>
    {
        #region Serialized Fields

        [SerializeField]
        private ScoreData scoreData;

        [FormerlySerializedAs("timeData")]
        [SerializeField]
        private GameTimeData gameTimeData;

        [SerializeField]
        private TMP_Text scoreText, timeText;

        #endregion

        private readonly StringBuilder _stringBuilder = new();

        protected override void OnRegister()
        {
            GameManager.Instance.OnGameStart += ShowCanvas;

            scoreData.ScoreUpdated += OnScoreUpdated;
            gameTimeData.TimeUpdated += OnGameTimeUpdated;
        }

        protected override void OnUnregister()
        {
            GameManager.Instance.OnGameStart -= ShowCanvas;

            scoreData.ScoreUpdated -= OnScoreUpdated;
            gameTimeData.TimeUpdated -= OnGameTimeUpdated;
        }

        private void ShowCanvas()
        {
            UIManager.Instance.ShowCanvas<GameplayCanvasPresenter>();
        }

        private void OnScoreUpdated(int currentScore)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append("Score: ").Append(currentScore);

            scoreText.text = _stringBuilder.ToString();
        }

        private void OnGameTimeUpdated(float currentTime)
        {
            timeText.text = currentTime.ToString("F2");
        }
    }
}