using System;

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

        public void Start()
        {
            Console.WriteLine("Language Processor - F.C. 2021");
            Console.WriteLine("Type 'quit' to terminate");
            Console.WriteLine("Type 'help' to show the help");
            Console.WriteLine();

            var quit = false;
            while (!quit)
            {
                Console.Write("command> ");
                switch (Console.ReadLine())
                {
                    case "quit":
                        quit = true;
                        break;
                    case "help":
                        HandleHelp();
                        break;
                    case { } input:
                        HandleInput(input);
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

        private void HandleInput(string input)
        {
            try
            {
                var postulate = _inputService.ParseInput(input);
                Console.WriteLine(postulate);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
