﻿using System.Collections.Generic;

namespace DefaultNamespace
{
    public static partial class TimeRemainingExtensions
    {
        private static readonly List<ITimeRemaining> _timeRemainings = new List<ITimeRemaining>();

        public static List<ITimeRemaining> TimeRemainings => _timeRemainings;

        public static void AddTimeRemaining(this ITimeRemaining value)
        {
            if (_timeRemainings.Contains(value)) return;
            value.CurrentTime = value.Time;
            _timeRemainings.Add(value);
        }

        public static void RemoveTimeRemaining(this ITimeRemaining value)
        {
            if (!_timeRemainings.Contains(value)) return;
            _timeRemainings.Remove(value);
        }

        public static void RemoveAllTimer(this ITimeRemaining value)
        {
            _timeRemainings.Clear();
        }
    }
}