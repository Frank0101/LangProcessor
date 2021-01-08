using System.Text.RegularExpressions;
using LangProcessor.Domain.Postulates;

namespace LangProcessor.ConsoleApp.InputParsers
{
    public class TypeInputParser : IInputParser
    {
        private readonly Regex _matchingRegex = new(@"^(\w+) (is a|is an) (\w+)$");

        public string HelpMessage => $"Type: {_matchingRegex}";

        public bool CanParse(string input) => _matchingRegex.IsMatch(input);

        public IPostulate Parse(string input)
        {
            var matchingGroups = _matchingRegex.Match(input).Groups;
            var (instance, type) = (matchingGroups[1].Value, matchingGroups[3].Value);
            return new TypePostulate(instance, type);
        }
    }
}
