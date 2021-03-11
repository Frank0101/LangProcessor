using System.Text.RegularExpressions;

namespace LangProcessor.Domain.LexicalAnalysis.Models
{
    public class TokenSpec
    {
        public string Type { get; }
        public string Pattern { get; }
        public Regex Regex { get; }

        public TokenSpec(string type, string pattern)
        {
            Type = type;
            Pattern = pattern;
            Regex = new Regex(Pattern);
        }
    }
}
