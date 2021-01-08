using LangProcessor.ConsoleApp.Services;
using LangProcessor.ConsoleApp.Services.InputParsers;
using Microsoft.Extensions.DependencyInjection;

namespace LangProcessor.ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            using var serviceProvider = RegisterDependencies();
            var applicationService = serviceProvider.GetRequiredService<IApplicationService>();
            applicationService.Start();
        }

        private static ServiceProvider RegisterDependencies()
        {
            return new ServiceCollection()

                // console
                .AddScoped<IInputParser, SynonymInputParser>()
                .AddScoped<IInputService, InputService>()
                .AddScoped<IApplicationService, ApplicationService>()
                .BuildServiceProvider();
        }
    }
}
