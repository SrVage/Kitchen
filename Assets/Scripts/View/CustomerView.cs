using System;
using UnityEngine;
using UnityEngineInternal;

namespace DefaultNamespace
{
    public class CustomerView:MonoBehaviour
    {
        private bool _visible;

        public void Move()
        {
            transform.position -= new Vector3(0, 0, 4);
        }
        
    }
}