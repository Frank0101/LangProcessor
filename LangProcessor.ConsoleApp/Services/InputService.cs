using System;
using System.Collections.Generic;
using System.Linq;
using LangProcessor.ConsoleApp.Services.InputParsers;
using LangProcessor.Domain.Models.Postulates;

namespace LangProcessor.ConsoleApp.Services
{
    public class InputService : IInputService
    {
        private readonly IEnumerable<IInputParser> _inputParsers;

        public InputService(IEnumerable<IInputParser> inputParsers)
        {
            _inputParsers = inputParsers;
        }

        public IPostulate ParseInput(string input)
        {
            var validInputParsers = _inputParsers
                .Where(inputParser => inputParser.CanParse(input))
                .ToList();

            if (!validInputParsers.Any())
            {
                throw new ArgumentException($"Input {input} is not recognised");
            }

            if (validInputParsers.Count > 1)
            {
                throw new ArgumentException($"Input {input} is not ambiguous");
            }

            return validInputParsers.Single().Parse(input);
        }
    }
}
