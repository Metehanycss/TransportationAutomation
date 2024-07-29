using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using TaşımacılıkOtomasyonu;

namespace TaşımacılıkOtomasyonu
{
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer("Server=MY;Database=TasimacilikDb;Trusted_Connection=True;TrustServerCertificate=True"));
                    services.AddTransient<MainWindow>();
                    services.AddTransient<LoginWindow>();
                    services.AddTransient<DriverWindow>();
                    services.AddTransient<VehicleWindow>();
                    services.AddTransient<RouteWindow>();
                    services.AddTransient<ShipmentWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var loginWindow = _host.Services.GetRequiredService<LoginWindow>();
            loginWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            base.OnExit(e);
        }
    }
}
