using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LangProcessor.Domain.LexicalAnalysis.Models;

namespace LangProcessor.Domain.LexicalAnalysis.Services
{
    public class LexicalAnalyser : ILexicalAnalyser
    {
        private readonly (string SymbolType, Regex Regex)[] _regexes;

        public LexicalAnalyser(IEnumerable<LexicalRule> rules)
        {
            _regexes = rules
                .Select(rule => (
                    rule.SymbolType,
                    new Regex(rule.Pattern, RegexOptions.Compiled)
                ))
                .ToArray();
        }

        public IEnumerable<Symbol> Analyse(string input)
        {
            while (input.Length > 0)
            {
                var matches = _regexes
                    .Select(tuple => (
                        tuple.SymbolType,
                        Match: tuple.Regex.Match(input)
                    ))
                    .Where(tuple => tuple.Match != null)
                    .OrderBy(tuple => tuple.Match.Index)
                    .ToArray();

                if (matches.Any())
                {
                    var (symbolType, match) = matches.First();
                    input = input.Substring(match.Index + match.Length);
                    yield return new Symbol(symbolType, match.Value);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
