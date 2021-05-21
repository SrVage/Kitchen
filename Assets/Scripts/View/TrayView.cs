using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TrayView : MonoBehaviour
    {

        public event Action<byte> DeleteTray;
        public void MoveTray(byte customer)
        {
            StartCoroutine(Move(customer));
        }

        private IEnumerator Move(byte customer)
        {
            var wait = new WaitForSeconds(0.01f);
            if (customer == 1)
            {
                var list = FindObjectsOfType<CustomerView>();
                foreach (var VARIABLE in list)
                {
                    if (VARIABLE.gameObject.transform.position.z == 0)
                    {
                        transform.parent = VARIABLE.gameObject.transform;
                    }
                }
                while (transform.position.x < -3)
                {
                    transform.position += new Vector3(0.08f, 0, 0);
                    yield return wait;
                }
                transform.position = transform.parent.position+ new Vector3(0, 1, -1);
                yield return new WaitForSeconds(0.5f);
                DeleteTray(1);
            }
            if (customer == 2)
            {
                var list = FindObjectsOfType<Customer2View>();
                foreach (var VARIABLE in list)
                {
                    if (VARIABLE.gameObject.transform.position.z == 0)
                    {
                        transform.parent = VARIABLE.gameObject.transform;
                    }
                }
                while (transform.position.x < 2.5f)
                {
                    transform.position += new Vector3(0.08f, 0, 0);
                    yield return wait;
                }
                transform.position = transform.parent.position+ new Vector3(0, 1, -1);
                yield return new WaitForSeconds(0.5f);
                DeleteTray(2);
            }
            if (customer == 0)
            {
                gameObject.AddComponent<Rigidbody>();
                while (transform.position.x < 6.5f)
                {
                    transform.position += new Vector3(0.08f, 0, 0);
                    yield return wait;
                }
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObject);
            }
        }
        }
    }