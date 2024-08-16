using System.Text;
using Project.Data;
using TMPro;
using UnityEngine;

namespace Project.UI
{
    public class PlayCanvasController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private ScoreDataSO scoreData;

        [SerializeField]
        private TimeDataSO timeData;

        [SerializeField]
        private TMP_Text scoreText, timeText;

        #endregion

        private readonly StringBuilder _stringBuilder = new();

        #region Event Functions

        private void OnEnable()
        {
            scoreData.OnScoreUpdated += OnScoreUpdated;
            timeData.OnTimeUpdated += OnTimeUpdated;
        }

        private void OnDisable()
        {
            scoreData.OnScoreUpdated -= OnScoreUpdated;
            timeData.OnTimeUpdated -= OnTimeUpdated;
        }

        #endregion

        private void OnScoreUpdated(int currentScore)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append("Score: ").Append(currentScore);

            scoreText.text = _stringBuilder.ToString();
        }

        private void OnTimeUpdated(float currentTime)
        {
            timeText.text = currentTime.ToString("F2");
        }
    }
}