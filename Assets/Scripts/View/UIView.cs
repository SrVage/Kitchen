using System;
using System.Collections;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class UIView:MonoBehaviour
    {

        public event Action<BlockState> CreateBlockOnTray;
        public event Action Reset; 
        public event Action Finish;
        [SerializeField] private GameObject _customer1;
        [SerializeField] private GameObject _customer2;
        [SerializeField] private Image _customerTime1;
        [SerializeField] private Image _customerTime2;
        [SerializeField] private Text Score;
        [SerializeField] private Text Score2;
        [SerializeField] private GameObject _endMenu;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private Text _finalScore;
        [SerializeField] private AudioClip[] _clip;
        private AudioSource _audioSource;
        private float _currentTime1;
        private float _currentTime2;
        private bool _isEnd = false;
        private int _score = 0;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Scores(int score)
        {
            Score.text = "Score: " + score.ToString();
            Score2.text = "Score: " + score.ToString();
            if (score > _score) _audioSource.PlayOneShot(_clip[0]);
            if (score<_score) _audioSource.PlayOneShot(_clip[1]);
            _score = score;
        }
        public void CreateFirstCustomerNeed(GameObject first, GameObject second, GameObject third, float time)
        {
            first.transform.SetParent(_customer1.transform);
            second.transform.SetParent(_customer1.transform);
            third.transform.SetParent(_customer1.transform);
            StopCoroutine(Time1(0));
            StartCoroutine(Time1(time));
        }
        
        public void CreateSecondCustomerNeed(GameObject first, GameObject second, GameObject third, float time)
        {
            first.transform.SetParent(_customer2.transform);
            second.transform.SetParent(_customer2.transform);
            third.transform.SetParent(_customer2.transform);
            StopCoroutine(Time2(0));
            StartCoroutine(Time2(time));
        }

        public void RemoveFirstCustomer()
        {
            _currentTime1 = 0;
        }
        
        public void RemoveSecondCustomer()
        {
            _currentTime2 = 0;
        }

        private IEnumerator Time1(float time)
        {
            _currentTime1 = time;
            while (_currentTime1 > 0)
            {
                _currentTime1 -= Time.deltaTime;
                _customerTime1.fillAmount = _currentTime1 / time;
               yield return null; 
            }
        }
        
        private IEnumerator Time2(float time)
        {
            _currentTime2 = time;
            while (_currentTime2 > 0)
            {
                _currentTime2 -= Time.deltaTime;
                _customerTime2.fillAmount = _currentTime2 / time;
                yield return null;
            }
        }

        public void CreateBlue()
        {
            if (_isEnd) return;
            CreateBlockOnTray?.Invoke(BlockState.BlueCube);
        }

        public void CreateGreen()
        {
            if (_isEnd) return;
            CreateBlockOnTray?.Invoke(BlockState.GreenCube);
        }

        public void CreateRed()
        {
            if (_isEnd) return;
            CreateBlockOnTray?.Invoke(BlockState.RedSphere);
        }

        public void FinishOrder()
        {
            if (_isEnd) return;
            Finish?.Invoke();
        }

        public void EndGame(int score)
        {
            _isEnd = true;
            _endMenu.SetActive(true);
            Time.timeScale = 0;
            _finalScore.text ="Score: " + score.ToString();
        }

        public void Restart()
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            Reset?.Invoke();
            Invoke(nameof(Load), 0.1f);
        }

        private void Load()
        {
            SceneManager.LoadScene(0);
        }
        
        public void Pause()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
        public void Resume()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}