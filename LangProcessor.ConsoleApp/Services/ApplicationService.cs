using System;

namespace LangProcessor.ConsoleApp.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IInputService _inputService;

        public ApplicationService(IInputService inputService)
        {
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
                        PrintHelp();
                        break;
                    case { } input:
                        HandleInput(input);
                        break;
                }
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

        private static void PrintHelp()
        {
            throw new NotImplementedException();
        }
    }
}
