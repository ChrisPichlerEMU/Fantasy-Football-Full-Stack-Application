using FantasyFootball.Core.Application.Services;
using FantasyFootball.Core.Infrastructure.Clients;
using FantasyFootball.Models.Interfaces;
using FantasyFootball.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using System.Net.Http;
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
        try
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"An error occurred during the execution of an HTTP request. Message: {ex.Message}",
                "An HTTP Error Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            Shutdown();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An unexpected error occurred during startup: {ex.Message}",
                "An Error Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            Shutdown();
        }
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}