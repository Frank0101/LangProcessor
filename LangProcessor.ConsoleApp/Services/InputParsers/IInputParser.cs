using LangProcessor.Domain.Models.Postulates;

namespace LangProcessor.ConsoleApp.Services.InputParsers
{
    public interface IInputParser
    {
        string HelpMessage { get; }
        bool CanParse(string input);
        IPostulate Parse(string input);
    }
}
