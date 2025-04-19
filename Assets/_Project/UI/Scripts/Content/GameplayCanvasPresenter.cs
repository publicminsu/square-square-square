using System.Text;
using Project.GameTime;
using Project.Score;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.UI.Content
{
    public class GameplayCanvasPresenter : CanvasPresenter
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

        #region Event Functions

        private void OnEnable()
        {
            scoreData.ScoreUpdated += OnScoreUpdated;
            gameTimeData.TimeUpdated += OnGameTimeUpdated;
        }

        private void OnDisable()
        {
            scoreData.ScoreUpdated -= OnScoreUpdated;
            gameTimeData.TimeUpdated -= OnGameTimeUpdated;
        }

        #endregion

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