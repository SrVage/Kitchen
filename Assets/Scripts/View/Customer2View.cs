using UnityEngine;

namespace DefaultNamespace
{
    public class Customer2View:MonoBehaviour
    {
        private bool _visible;

        public void Move()
        {
            transform.position -= new Vector3(0, 0, 2);
        }
    }
}