using Drones.Model.Entities;
using Drones.Model.Repository.Interfaces;
using Drones.Services.Interfaces;

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
                var droneRepository = scope.ServiceProvider.GetRequiredService<IRepository<Drone>>();

                var drones = droneRepository.GetAllAsync().GetAwaiter().GetResult();
                if (drones != null)
                {
                    var dronesService = scope.ServiceProvider.GetRequiredService<IDronesService>();

                    drones.ToList().ForEach(d => 
                    {
                        _logger.LogInformation($"The drone battery's level is {d.BatteryLevel}% and its state is {d.State}");

                        dronesService.CheckDronBatteryLevelAndState(d,"IDLE").GetAwaiter().GetResult();

                    });
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
