using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class TimeRemainingController:IExecute
    {
        private readonly List<ITimeRemaining> _timeRemaining;

        public TimeRemainingController()
        {
            _timeRemaining = TimeRemainingExtensions.TimeRemainings;
        }
        
        public void Execute(float deltaTime)
        {
            for (int i =0; i<_timeRemaining.Count; i++)
            {
                var Timer = _timeRemaining[i];
                Timer.CurrentTime -= deltaTime;
                if (Timer.CurrentTime <= 0.0f)
                {
                    Timer?.Method?.Invoke();
                    Timer.RemoveTimeRemaining();
                }
            }
        }
    }
}