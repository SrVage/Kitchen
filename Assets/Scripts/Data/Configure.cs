using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class Configure:ScriptableObject
    {
        [SerializeField] private List<GameObject> _blockForOrder;
        [SerializeField] private List<Sprite> _needBlock;
        [SerializeField] private GameObject _tray;
        [SerializeField] private GameObject _customer;
        [SerializeField] private AudioClip _scoreUp;
        [SerializeField] private AudioClip _scoreDown;
        [SerializeField] private Vector3 _pointOfSpawn;
        [SerializeField] private Vector3 _pointOfCustomer1;
        [SerializeField] private Vector3 _pointOfCustomer2;

        public List<GameObject> ForOrder => _blockForOrder;

        public GameObject Tray => _tray;

        public Vector3 PointOfSpawn => _pointOfSpawn;

        public List<Sprite> NeedBlock => _needBlock;

        public GameObject Customer => _customer;

        public Vector3 PointOfCustomer1 => _pointOfCustomer1;

        public Vector3 PointOfCustomer2 => _pointOfCustomer2;

        public AudioClip ScoreUp => _scoreUp;

        public AudioClip ScoreDown => _scoreDown;
    }
}