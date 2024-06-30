using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniKanbanBoard.Models;
using MiniKanbanBoard.ViewModels;
using MiniKanbanBoard.Views;
using System.Windows;

namespace MiniKanbanBoard;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    [STAThread]
    public static void Main()
    {
        using IHost host = CreateHostBuilder().Build();
        host.Start();

        var app = new App()
        {
            MainWindow = host.Services.GetRequiredService<HostWindowView>()
        };
        app.Run(app.MainWindow);
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder().
            ConfigureServices(services =>
            {
                services.AddSingleton<HostWindowView>();
                services.AddSingleton<HostWindowViewModel>();
                services.AddSingleton<HostWindowModel>();


            });
    }
}
