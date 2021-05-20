using DefaultNamespace;

namespace Controller
{
    public sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Configure config)
        {
            var ui = new UIController(config);
            var time = new TimeRemainingController();
            var customer = new CustomerController(config, ui);
            var timeController = new TimerController();
            controllers.Add(ui);
            controllers.Add(time);
            controllers.Add(customer);
            controllers.Add(timeController);
        }
    }
}