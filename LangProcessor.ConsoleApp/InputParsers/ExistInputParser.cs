using System.Text.RegularExpressions;
using LangProcessor.Domain.Postulates;

namespace LangProcessor.ConsoleApp.InputParsers
{
    public class ExistInputParser : IInputParser
    {
        private readonly Regex _matchingRegex = new(@"^(\w+)$");

        public string HelpMessage => $"Exist: {_matchingRegex}";

        public bool CanParse(string input) => _matchingRegex.IsMatch(input);

        public IPostulate Parse(string input) =>
            new ExistPostulate(input);
    }
}
