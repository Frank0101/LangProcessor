using System.Collections.Generic;
using LangProcessor.Domain.LexicalAnalysis.Models;

namespace LangProcessor.Domain.LexicalAnalysis.Services
{
    public interface ILexicalAnalyser
    {
        IEnumerable<Token> Analyse(string input);
    }
}
