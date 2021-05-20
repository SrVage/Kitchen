using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TimerView:MonoBehaviour
    {
        [SerializeField] private Text _timer1;
        [SerializeField] private Text _timer2;

        public void SetTimer(string text)
        {
            _timer1.text = text;
            _timer2.text = text;
        }
    }
}