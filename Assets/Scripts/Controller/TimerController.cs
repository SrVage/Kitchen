using System;
using DefaultNamespace;
using Object = UnityEngine.Object;

namespace Controller
{
    public sealed class TimerController:IInitialization, IExecute
    {
        public event Action<bool> StopGame;
        
        private float _time;
        private byte _minutes;
        private byte _seconds;
        private TimerView _TimerView;
        
        public TimerController()
        {
        }

        public void Initialize()
        {
            _time = 60f;
            _TimerView = Object.FindObjectOfType<TimerView>();
        }

        public void Execute(float deltaTime)
        {
            _time -= deltaTime;
            Translate();
            if (_time <= 0) StopGame?.Invoke(true);
        }

        private void Translate()
        {
            _minutes = (byte)(_time / 60);
            _seconds = (byte)(_time % 60);
            _TimerView.SetTimer($"0{_minutes}:{_seconds}");
        }
    }
}