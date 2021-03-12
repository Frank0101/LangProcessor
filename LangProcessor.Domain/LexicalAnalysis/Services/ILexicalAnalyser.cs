using System.Collections.Generic;
using LangProcessor.Domain.LexicalAnalysis.Models;

namespace LangProcessor.Domain.LexicalAnalysis.Services
{
    public interface ILexicalAnalyser
    {
        IEnumerable<Symbol> Analyse(string input);
    }
}
