using System;
using LangProcessor.Domain.Models;

namespace LangProcessor.ConsoleApp.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IInputHelpService _inputHelpService;
        private readonly IInputService _inputService;

        public ApplicationService(IInputHelpService inputHelpService,
            IInputService inputService)
        {
            _inputHelpService = inputHelpService;
            _inputService = inputService;
        }

        public void Start(Knowledge knowledge)
        {
            Console.WriteLine("Language Processor - F.C. 2021");
            Console.WriteLine("Type 'quit' to terminate");
            Console.WriteLine("Type 'help' to show the help");
            Console.WriteLine();

            var quit = false;
            while (!quit)
            {
                Console.Write("command> ");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "quit":
                        quit = true;
                        break;
                    case "help":
                        HandleHelp();
                        break;
                    case { } input:
                        HandleInput(input, knowledge);
                        break;
                }
            }
        }

        private void HandleHelp()
        {
            foreach (var helpMessage in _inputHelpService.GetInputHelpMessages())
            {
                Console.WriteLine(helpMessage);
            }
        }

        private void HandleInput(string input, Knowledge knowledge)
        {
            try
            {
                var postulate = _inputService.ParseInput(input);
                postulate.Teach(knowledge);

                Console.WriteLine($"Teaching {postulate}..");
                Console.WriteLine($"Knowledge is {knowledge}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
