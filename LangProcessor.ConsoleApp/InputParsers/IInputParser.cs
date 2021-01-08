using LangProcessor.Domain.Postulates;

namespace LangProcessor.ConsoleApp.InputParsers
{
    public interface IInputParser
    {
        string HelpMessage { get; }
        bool CanParse(string input);
        IPostulate Parse(string input);
    }
}
