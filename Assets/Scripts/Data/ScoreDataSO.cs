using System;
using UnityEngine;

namespace Project.Data
{
    /// <summary>
    /// 점수를 관리하는 ScriptableObject
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Score")]
    public class ScoreDataSO : ScriptableObject
    {
        /// <summary>
        /// 현재 점수
        /// </summary>
        private int _currentScore;

        /// <summary>
        /// 점수가 업데이트될 때 호출할 이벤트
        /// </summary>
        public event Action<int> ScoreUpdated;

        /// <summary>
        /// 점수를 0으로 초기화
        /// </summary>
        public void InitScore()
        {
            SetScore(0);
        }

        /// <summary>
        /// 점수를 1만큼 올려줌
        /// </summary>
        public void IncreaseScore()
        {
            SetScore(_currentScore + 1);
        }

        /// <summary>
        /// 점수를 설정
        /// </summary>
        /// <param name="score">설정할 점수</param>
        private void SetScore(int score)
        {
            _currentScore = score;
            ScoreUpdated?.Invoke(_currentScore);
        }
    }
}