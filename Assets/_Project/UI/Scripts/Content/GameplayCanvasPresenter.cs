using System.Text;
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
            scoreData.ScoreUpdated += OnScoreUpdated;
            gameTimeData.TimeUpdated += OnGameTimeUpdated;
        }

        protected override void OnUnregister()
        {
            scoreData.ScoreUpdated -= OnScoreUpdated;
            gameTimeData.TimeUpdated -= OnGameTimeUpdated;
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