using System.Collections.Generic;
using DefaultNamespace;

namespace Controller
{
    public sealed class Controllers:IInitialization, IExecute, IEndGame
    {
        private List<IInitialization> _initializationsList;
        private List<IExecute> _executesList;
        private List<IEndGame> _endGames;
        private bool _isStopped;
        private TimerController _timerController;
        public Controllers()
        {
            _initializationsList = new List<IInitialization>();
            _executesList = new List<IExecute>();
            _endGames = new List<IEndGame>();
            _isStopped = false;
        }

        public Controllers Add(IController controller)
        {
            if (controller is IExecute executor) _executesList.Add(executor);
            if (controller is IInitialization initializator) _initializationsList.Add(initializator);
            if (controller is IEndGame endGame) _endGames.Add(endGame);
            if (controller is TimerController timer)
            {
                _timerController = timer;
                _timerController.StopGame += StopGame;
            }
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
            if (_isStopped) return;
            foreach (var VARIABLE in _executesList)
            {
                VARIABLE.Execute(deltaTime);
            }
        }

        private void StopGame(bool state)
        {
            _isStopped = true;
            EndGame();
        }

        public void EndGame()
        {
            foreach (var VARIABLE in _endGames)
            {
                VARIABLE.EndGame();
            }
            _timerController.StopGame -= StopGame;
        }
    }
}