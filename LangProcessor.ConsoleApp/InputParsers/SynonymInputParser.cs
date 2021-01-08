using System;
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
            return (matchingGroups[1].Value, matchingGroups[3].Value) switch
            {
                var (value1, value2) when value1 != value2 => new SynonymPostulate(value1, value2),
                var (value1, value2) when value1 == value2 => new ExistPostulate(value1),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
