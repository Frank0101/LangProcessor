using System.Collections.Generic;
using LangProcessor.Domain.LexicalAnalysis.Models;

namespace LangProcessor.Domain.LexicalAnalysis.Services
{
    public class LexicalAnalyser : ILexicalAnalyser
    {
        private readonly IEnumerable<TokenSpec> _tokenSpecs;

        public LexicalAnalyser(IEnumerable<TokenSpec> tokenSpecs)
        {
            _tokenSpecs = tokenSpecs;
        }

        public IEnumerable<Token> Analyse(string input)
        {
            return new Token[] { };
        }
    }
}
