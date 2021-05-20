using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TrayView:MonoBehaviour
    {
        public void MoveTray(byte customer)
        {
            StartCoroutine(Move(customer));
        }
        
        private IEnumerator Move(byte customer)
        {
            var wait = new WaitForSeconds(0.01f);
            if (customer == 1)
            {
                while (transform.position.x < -3)
                {
                    transform.position += new Vector3(0.05f, 0, 0);
                    yield return wait;
                }
                Destroy(this.gameObject);
            }
            if (customer == 2)
            {
                while (transform.position.x < 3)
                {
                    transform.position += new Vector3(0.05f, 0, 0);
                    yield return wait;
                }
                Destroy(this.gameObject);
            }

            if (customer == 0)
            {
                gameObject.AddComponent<Rigidbody>();
                while (transform.position.x < 6.5f)
                {
                    transform.position += new Vector3(0.05f, 0, 0);
                    yield return wait;
                }
                yield return new WaitForSeconds(0.5f);
                    Destroy(gameObject);  
            }
        }
    }
}