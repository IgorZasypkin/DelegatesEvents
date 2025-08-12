using DelegatesEvents.Helpers;
using DelegatesEvents.Interfaces;
using DelegatesEvents.Models;
using DelegatesEvents.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DelegatesEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var demoService = host.Services.GetRequiredService<DemoService>();
            demoService.RunDemo();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Конфигурация
                    services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));

                    // Регистрация сервисов
                    services.AddTransient<IFileSearcher, FileSearcher>();
                    services.AddTransient<ITestDataGenerator, TestDataGenerator>();
                    services.AddTransient<DemoService>();
                });
    }
}
