using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Controller
{
    public sealed class UIController:IInitialization,IExecute, IEndGame
    {
        public event Action<byte> DestroyCustomer; 
        
        private UIView _UIView;
        private Configure _config;
        private GameObject[] _firstCustomer = new GameObject[3];
        private GameObject[] _secondCustomer = new GameObject[3];
        private GameObject tray;
        private BlockFactory blockFactory;
        private TrayBlock _playerTray;
        private TrayBlock _firstCustomerTray;
        private TrayBlock _secondCustomerTray;
        private ITimeRemaining _timeRemaining;
        private ITimeRemaining _timeRemaining1;
        private ITimeRemaining _timeRemaining2;
        private int _scores=0;

        public UIController(Configure config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            _UIView = Object.FindObjectOfType<UIView>();
            _firstCustomer[0] = new GameObject("first", typeof(Image));
            _firstCustomer[1] = new GameObject("second", typeof(Image));
            _firstCustomer[2] = new GameObject("third", typeof(Image));
            _secondCustomer[0] = new GameObject("first", typeof(Image));
            _secondCustomer[1] = new GameObject("second", typeof(Image));
            _secondCustomer[2] = new GameObject("third", typeof(Image));
            _UIView.CreateBlockOnTray += Create;
            _UIView.Finish += CompareTray;
            blockFactory = new BlockFactory();
            CreateFirstCustomerNeed();
            CreatePlayerTray();
            CreateSecondCustomerNeed();
        }

        private void CreatePlayerTray()
        {
            tray = GameObject.Instantiate(_config.Tray, _config.PointOfSpawn, Quaternion.identity);
            tray.AddComponent<TrayView>();
            _playerTray = new TrayBlock();
        }

        public void Execute(float deltaTime)
        {
        }

        private void CompareTray()
        {

            if (_playerTray.CompareBlock(_firstCustomerTray))
            {
                _scores+=2;
                tray.GetComponent<TrayView>().MoveTray(1);
                RemoveFirstCustomer();
                CreatePlayerTray();
                return;
            }
            if (_playerTray.CompareBlock(_secondCustomerTray))
            {
                _scores+=2;
                tray.GetComponent<TrayView>().MoveTray(2);
                RemoveSecondCustomer();
                CreatePlayerTray();
                return;
            }
            tray.GetComponent<TrayView>().MoveTray(0);
                CreatePlayerTray();
                _scores--;
                _UIView.Scores(_scores);
        }

        public void Create(BlockState blockState)
        {
            if (_playerTray.FirstBlock == BlockState.None)
            {
                if (blockState == BlockState.BlueCube)
                    GameObject.Instantiate(_config.ForOrder[0], tray.transform.position-new Vector3(0.5f,0,0), Quaternion.identity,
                        tray.transform);
                if (blockState == BlockState.GreenCube)
                    GameObject.Instantiate(_config.ForOrder[1], tray.transform.position-new Vector3(0.5f,0,0), Quaternion.identity,
                        tray.transform);
                if (blockState == BlockState.RedSphere)
                    GameObject.Instantiate(_config.ForOrder[2], tray.transform.position-new Vector3(0.5f,0,0), Quaternion.identity,
                        tray.transform);
                _playerTray.FirstBlock = blockState;
                return;
            }

            if (_playerTray.SecondBlock == BlockState.None)
            {
                if (blockState == BlockState.BlueCube)
                    GameObject.Instantiate(_config.ForOrder[0], tray.transform.position, Quaternion.identity,
                        tray.transform);
                if (blockState == BlockState.GreenCube)
                    GameObject.Instantiate(_config.ForOrder[1], tray.transform.position, Quaternion.identity,
                        tray.transform);
                if (blockState == BlockState.RedSphere)
                    GameObject.Instantiate(_config.ForOrder[2], tray.transform.position, Quaternion.identity,
                        tray.transform);
                _playerTray.SecondBlock = blockState;
                return;
            }
            
            if (_playerTray.ThirdBlock == BlockState.None)
            {
                if (blockState == BlockState.BlueCube)
                    GameObject.Instantiate(_config.ForOrder[0], tray.transform.position+new Vector3(0.5f,0,0), Quaternion.identity,
                        tray.transform);
                if (blockState == BlockState.GreenCube)
                    GameObject.Instantiate(_config.ForOrder[1], tray.transform.position+new Vector3(0.5f,0,0), Quaternion.identity,
                        tray.transform);
                if (blockState == BlockState.RedSphere)
                    GameObject.Instantiate(_config.ForOrder[2], tray.transform.position+new Vector3(0.5f,0,0), Quaternion.identity,
                        tray.transform);
                _playerTray.ThirdBlock = blockState;
                return;
            }
        }

        private void CreateFirstCustomerNeed()
        {
            _firstCustomer[0].SetActive(false);
            _firstCustomer[1].SetActive(false);
            _firstCustomer[2].SetActive(false);
            _firstCustomerTray = blockFactory.CreateTrayBlock();
            if (_firstCustomerTray.FirstBlock != BlockState.None)
            {
                _firstCustomer[0].GetComponent<Image>().sprite = _config.NeedBlock[(int)_firstCustomerTray.FirstBlock-1];
                _firstCustomer[0].SetActive(true);
            }
            if (_firstCustomerTray.SecondBlock != BlockState.None)
            {
                _firstCustomer[1].GetComponent<Image>().sprite = _config.NeedBlock[(int)_firstCustomerTray.SecondBlock-1];
                _firstCustomer[1].SetActive(true);
            }
            if (_firstCustomerTray.ThirdBlock != BlockState.None)
            {
                _firstCustomer[2].GetComponent<Image>().sprite = _config.NeedBlock[(int)_firstCustomerTray.ThirdBlock-1];
                _firstCustomer[2].SetActive(true);
            }
            float time = Random.Range(4, 8);
            _timeRemaining1 = new TimeRemaining(RemoveFirstCustomer, time);
            _timeRemaining1.AddTimeRemaining();
            _UIView.CreateFirstCustomerNeed(_firstCustomer[0], _firstCustomer[1], _firstCustomer[2], time);
        }
        
        private void CreateSecondCustomerNeed()
        {
            _secondCustomer[0].SetActive(false);
            _secondCustomer[1].SetActive(false);
            _secondCustomer[2].SetActive(false);
            _secondCustomerTray = blockFactory.CreateTrayBlock();
            if (_secondCustomerTray.FirstBlock != BlockState.None)
            {
                _secondCustomer[0].GetComponent<Image>().sprite = _config.NeedBlock[(int)_secondCustomerTray.FirstBlock-1];
                _secondCustomer[0].SetActive(true);
            }
            if (_secondCustomerTray.SecondBlock != BlockState.None)
            {
                _secondCustomer[1].GetComponent<Image>().sprite = _config.NeedBlock[(int)_secondCustomerTray.SecondBlock-1];
                _secondCustomer[1].SetActive(true);
            }
            if (_secondCustomerTray.ThirdBlock != BlockState.None)
            {
                _secondCustomer[2].GetComponent<Image>().sprite = _config.NeedBlock[(int)_secondCustomerTray.ThirdBlock-1];
                _secondCustomer[2].SetActive(true);
            }
            float time = Random.Range(4, 8);
            _timeRemaining2 = new TimeRemaining(RemoveSecondCustomer, time);
            _timeRemaining2.AddTimeRemaining();
            _UIView.CreateSecondCustomerNeed(_secondCustomer[0], _secondCustomer[1], _secondCustomer[2], time);
        }

        private void RemoveFirstCustomer()
        {
            _scores-=1;
            DestroyCustomer?.Invoke(1);
            _UIView.Scores(_scores);
            _timeRemaining1.RemoveTimeRemaining();
            _UIView.RemoveFirstCustomer();
            _firstCustomerTray.FirstBlock = BlockState.None;
            _firstCustomerTray.SecondBlock = BlockState.None;
            _firstCustomerTray.ThirdBlock = BlockState.None;
            _firstCustomer[0].SetActive(false);
            _firstCustomer[1].SetActive(false);
            _firstCustomer[2].SetActive(false);
            _timeRemaining = new TimeRemaining(CreateFirstCustomerNeed, 2);
            _timeRemaining.AddTimeRemaining();
        }
        private void RemoveSecondCustomer()
        {
            _scores-=1;
            DestroyCustomer?.Invoke(2);
            _UIView.Scores(_scores);
            _timeRemaining2.RemoveTimeRemaining();
            _UIView.RemoveSecondCustomer();
            _secondCustomerTray.FirstBlock = BlockState.None;
            _secondCustomerTray.SecondBlock = BlockState.None;
            _secondCustomerTray.ThirdBlock = BlockState.None;
            _secondCustomer[0].SetActive(false);
            _secondCustomer[1].SetActive(false);
            _secondCustomer[2].SetActive(false);
            _timeRemaining = new TimeRemaining(CreateSecondCustomerNeed, 2);
            _timeRemaining.AddTimeRemaining();
        }

        public void EndGame()
        {
            _UIView.EndGame(_scores);
            _UIView.CreateBlockOnTray -= Create;
            _UIView.Finish -= CompareTray;
            _timeRemaining.RemoveAllTimer();
        }
    }
}