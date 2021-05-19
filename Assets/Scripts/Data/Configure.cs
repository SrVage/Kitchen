using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class Configure:ScriptableObject
    {
        [SerializeField] private List<ScriptableObject> _blockForOrder;
        [SerializeField] private GameObject _tray;
        [SerializeField] private Vector3 _pointOfSpawn;

        public List<ScriptableObject> ForOrder => _blockForOrder;

        public GameObject Tray => _tray;

        public Vector3 PointOfSpawn => _pointOfSpawn;
    }
}