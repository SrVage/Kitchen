using System;
using System.Collections.Generic;
using DefaultNamespace;

namespace Controller
{
    public class Controllers:IInitialization, IExecute
    {
        private List<IInitialization> _initializationsList;
        private List<IExecute> _executesList;
        public Controllers()
        {
            _initializationsList = new List<IInitialization>();
            _executesList = new List<IExecute>();
        }

        private Controllers Add(IController controller)
        {
            if (controller is IExecute executor) _executesList.Add(executor);
            if (controller is IInitialization initializator) _initializationsList.Add(initializator);
            return this;
        }
        
        public void Initialize()
        {
            foreach (var VARIABLE in _initializationsList)
            {
                VARIABLE.Initialize();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var VARIABLE in _executesList)
            {
                VARIABLE.Execute(deltaTime);
            }
        }
    }
}