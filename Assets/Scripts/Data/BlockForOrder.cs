using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class BlockForOrder:ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _object;

        public string Name => _name;

        public GameObject Object => _object;
    }
}