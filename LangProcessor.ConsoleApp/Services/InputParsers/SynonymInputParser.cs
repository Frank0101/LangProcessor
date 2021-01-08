using System.Text.RegularExpressions;
using LangProcessor.Domain.Models.Postulates;

namespace LangProcessor.ConsoleApp.Services.InputParsers
{
    public class SynonymInputParser : IInputParser
    {
        public bool CanParse(string input) =>
            Regex.IsMatch(input, @"^\w+ = \w$");

        public IPostulate Parse(string input)
        {
            var matches = Regex.Match(input, @"^{\w+} = {\w+}$");
            return new SynonymPostulate(matches.Groups[1].Value, matches.Groups[2].Value);
        }
    }
}
