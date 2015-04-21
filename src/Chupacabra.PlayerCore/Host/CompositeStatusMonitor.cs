namespace Chupacabra.PlayerCore.Host
{
    public class CompositeStatusMonitor : IStatusMonitor
    {
        private readonly IStatusMonitor _firstMonitor;
        private readonly IStatusMonitor _secondMonitor;

        public CompositeStatusMonitor(IStatusMonitor firstMonitor, IStatusMonitor secondMonitor)
        {
            _firstMonitor = firstMonitor;
            _secondMonitor = secondMonitor;
        }

        public void SetValue(string key, object value)
        {
            _firstMonitor.SetValue(key, value);
            _secondMonitor.SetValue(key, value);
        }

        public void ConfirmTurn()
        {
            _firstMonitor.ConfirmTurn();
            _secondMonitor.ConfirmTurn();
        }
    }
}
