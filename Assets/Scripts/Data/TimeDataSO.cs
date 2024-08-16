using System;
using UnityEngine;

namespace Project.Data
{
    /// <summary>
    /// 시간을 관리하는 ScriptableObject
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Time")]
    public class TimeDataSO : ScriptableObject
    {
        /// <summary>
        /// 현재 시간
        /// </summary>
        private float _currentTime;

        /// <summary>
        /// 시간이 업데이트될 때 호출할 이벤트
        /// </summary>
        public event Action<float> TimeUpdated;
        
        /// <summary>
        /// 시간을 0으로 초기화
        /// </summary>
        public void InitTime()
        {
            SetTime(0);
        }

        /// <summary>
        /// 시간을 deltaTime만큼 올려줌
        /// </summary>
        public void IncreaseTime()
        {
            SetTime(_currentTime + Time.deltaTime);
        }

        /// <summary>
        /// 시간을 설정
        /// </summary>
        /// <param name="time">설정할 시간</param>
        private void SetTime(float time)
        {
            _currentTime = time;
            TimeUpdated?.Invoke(_currentTime);
        }
    }
}