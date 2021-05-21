using Controller;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    public class CustomerFactory
    {
        private Configure _config;
        public CustomerFactory(Configure config)
        {
            _config = config;
        }

        public GameObject CreateCustomer(byte numOfQueue)
        {
            Random rnd = new Random();
            GameObject Customer;
            if (numOfQueue == 1)
            {
                Customer = GameObject.Instantiate(_config.Customer, _config.PointOfCustomer1, Quaternion.identity);
                Customer.AddComponent<CustomerView>();
                Customer.AddComponent<Rigidbody>().isKinematic = true;
                for (int i = 0; i < Customer.transform.childCount; i++)
                {
                    Customer.transform.GetChild(i).GetComponent<MeshRenderer>().material.color =
                        new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1);
                }
                Customer.tag = "Customer";
                return Customer;
            }
            else
            {
                Customer = GameObject.Instantiate(_config.Customer, _config.PointOfCustomer2, Quaternion.identity);
                Customer.AddComponent<Customer2View>();
                Customer.AddComponent<Rigidbody>().isKinematic = true;
                for (int i = 0; i < Customer.transform.childCount; i++)
                {
                    Customer.transform.GetChild(i).GetComponent<MeshRenderer>().material.color =
                        new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1);
                }
                Customer.tag = "Customer";
                return Customer;
            }
            
        }
    }
}