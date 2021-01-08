using LangProcessor.ConsoleApp.InputParsers;
using LangProcessor.ConsoleApp.Services;
using LangProcessor.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LangProcessor.ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            using var serviceProvider = RegisterDependencies();
            var applicationService = serviceProvider.GetRequiredService<IApplicationService>();
            applicationService.Start(new Knowledge());
        }

        private static ServiceProvider RegisterDependencies()
        {
            return new ServiceCollection()

                // Input Parsers
                .AddScoped<IInputParser, ExistInputParser>()
                .AddScoped<IInputParser, SynonymInputParser>()

                // Console Services
                .AddScoped<IInputHelpService, InputHelpService>()
                .AddScoped<IInputService, InputService>()
                .AddScoped<IApplicationService, ApplicationService>()
                .BuildServiceProvider();
        }
    }
}
