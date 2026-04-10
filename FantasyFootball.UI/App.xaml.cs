using FantasyFootball.Core.Domain.Services.Interfaces;
using FantasyFootball.Core.Domain.Services.Implementations;
using FantasyFootball.Core.Web.Clients;
using FantasyFootball.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Hosting;
using System.Windows;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // HTTP Client
                services.AddHttpClient<SportsDataClient>(client =>
                {
                    client.BaseAddress = new Uri("https://api.example.com/");
                });

                // Services from Core
                services.AddTransient<IPlayerService, PlayerService>();

                // ViewModels
               // services.AddTransient<MainViewModel>();

                // Windows
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}