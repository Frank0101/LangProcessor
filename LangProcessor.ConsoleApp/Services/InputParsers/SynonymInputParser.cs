using System.Text.RegularExpressions;
using LangProcessor.Domain.Models.Postulates;

namespace LangProcessor.ConsoleApp.Services.InputParsers
{
    public class SynonymInputParser : IInputParser
    {
        private readonly Regex _matchingRegex = new(@"^(\w+) = (\w+)$");

        public string HelpMessage => "Synonym: A = B";

        public bool CanParse(string input) => _matchingRegex.IsMatch(input);

        public IPostulate Parse(string input)
        {
            var matchingGroups = _matchingRegex.Match(input).Groups;
            return new SynonymPostulate(matchingGroups[1].Value, matchingGroups[2].Value);
        }
    }
}
