using LangProcessor.Domain.Models.Postulates;

namespace LangProcessor.ConsoleApp.Services.InputParsers
{
    public interface IInputParser
    {
        public bool CanParse(string input);
        public IPostulate Parse(string input);
    }
}
