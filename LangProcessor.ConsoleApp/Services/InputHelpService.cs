using System.Collections.Generic;
using System.Linq;
using LangProcessor.ConsoleApp.Services.InputParsers;

namespace LangProcessor.ConsoleApp.Services
{
    public class InputHelpService : IInputHelpService
    {
        private readonly IEnumerable<IInputParser> _inputParsers;

        public InputHelpService(IEnumerable<IInputParser> inputParsers)
        {
            _inputParsers = inputParsers;
        }

        public IEnumerable<string> GetInputHelpMessages() =>
            _inputParsers.Select(inputParser => inputParser.HelpMessage);
    }
}
