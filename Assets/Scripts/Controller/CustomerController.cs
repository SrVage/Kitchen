using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Controller
{
    public sealed class CustomerController:IInitialization, IEndGame
    {
        private CustomerFactory _customerFactory;
        private Configure _config;
        private ITimeRemaining _timeRemaining1;
        private ITimeRemaining _timeRemaining2;
        private UIController _ui;
        private List<GameObject> _customer1;
        private List<GameObject> _customer2;
        

        public CustomerController(Configure config, UIController ui)
        {
            _config = config;
            _ui = ui;
        }
        
        public void Initialize()
        {
            _customerFactory = new CustomerFactory(_config);
            _timeRemaining1 = new TimeRemaining(CreateFirstCustomer, 5);
            _timeRemaining1.AddTimeRemaining();
            _timeRemaining2 = new TimeRemaining(CreateSecondCustomer, 5);
            _timeRemaining2.AddTimeRemaining();
            _ui.DestroyCustomer += DestroyCustomer;
            _customer1 = new List<GameObject>();
            _customer2 = new List<GameObject>();
            CreateFirstCustomer();
            CreateFirstCustomer();
            CreateSecondCustomer();
            CreateSecondCustomer();
            Move();
        }

        private void DestroyCustomer(byte num)
        {
            if (num == 1)
            {
                GameObject.Destroy(_customer1[0]);
                _customer1.Remove(_customer1[0]);
            }

            if (num == 2)
            {
                GameObject.Destroy(_customer2[0]);
                _customer2.Remove(_customer2[0]);
            }
            Move();
        }

        private void CreateFirstCustomer()
        {
            if (_customer1.Count < 3)
            {
                var customer = _customerFactory.CreateCustomer(1);
                _customer1.Add(customer);
                Move();
            }
            _timeRemaining1 = new TimeRemaining(CreateFirstCustomer, 5);
            _timeRemaining1.AddTimeRemaining();
        }
        private void CreateSecondCustomer()
        {
            if (_customer2.Count < 3)
            {
               var customer = _customerFactory.CreateCustomer(2);
               _customer2.Add(customer);
               Move();
            }
            _timeRemaining2 = new TimeRemaining(CreateSecondCustomer, 5);
            _timeRemaining2.AddTimeRemaining();
        }

        private void Move()
        {
            for (int i = 0; i<_customer1.Count; i++)
            {
                _customer1[i].transform.position = new Vector3(_customer1[i].transform.position.x, _customer1[i].transform.position.y, 2*i);
            }
            for (int i = 0; i<_customer2.Count; i++)
            {
                _customer2[i].transform.position = new Vector3(_customer2[i].transform.position.x, _customer2[i].transform.position.y, 2*i);
            }
        }

        public void EndGame()
        {
            _ui.DestroyCustomer -= DestroyCustomer;
            _timeRemaining1.RemoveTimeRemaining();
            _timeRemaining2.RemoveTimeRemaining();
        }
    }
}