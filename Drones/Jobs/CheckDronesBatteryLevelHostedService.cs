using Drones.Model.Entities;
using Drones.Model.Repository.Interfaces;

namespace Drones.Jobs
{
    public class CheckDronesBatteryLevelHostedService : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private readonly ILogger<CheckDronesBatteryLevelHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public CheckDronesBatteryLevelHostedService(IServiceProvider serviceProvider, ILogger<CheckDronesBatteryLevelHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckDronesBatteryLevel, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
            return Task.CompletedTask;
        }

        private void CheckDronesBatteryLevel(object? state) 
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _droneRepository = scope.ServiceProvider.GetRequiredService<IRepository<Drone>>();

                var drones = _droneRepository.GetAllAsync().GetAwaiter().GetResult();
                if (drones != null)
                {
                    drones.ToList().ForEach(d => _logger.LogInformation($"The drone battery's level is {d.BatteryLevel}% and its state is {d.State}"));
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
