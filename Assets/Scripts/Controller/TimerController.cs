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
            Object.FindObjectOfType<UIView>().Reset += Stop;
        }

        public void Execute(float deltaTime)
        {
            _time -= deltaTime;
            Translate();
            if (_time <= 0) Stop();
        }

        private void Stop()
        {
            StopGame?.Invoke(true);
        }

        private void Translate()
        {
            _minutes = (byte)(_time / 60);
            _seconds = (byte)(_time % 60);
            if (_seconds < 10)
            {
                _TimerView.SetTimer($"0{_minutes}:0{_seconds}");
            }
            else
                _TimerView.SetTimer($"0{_minutes}:{_seconds}");
        }
    }
}