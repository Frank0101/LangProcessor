using System.Text.RegularExpressions;
using LangProcessor.Domain.Postulates;

namespace LangProcessor.ConsoleApp.InputParsers
{
    public class SynonymInputParser : IInputParser
    {
        private readonly Regex _matchingRegex = new(@"^(\w+) (=|is) (\w+)$");

        public string HelpMessage => $"Synonym: {_matchingRegex}";

        public bool CanParse(string input) => _matchingRegex.IsMatch(input);

        public IPostulate Parse(string input)
        {
            var matchingGroups = _matchingRegex.Match(input).Groups;
            var (value1, value2) = (matchingGroups[1].Value, matchingGroups[3].Value);
            return new SynonymPostulate(value1, value2);
        }
    }
}
