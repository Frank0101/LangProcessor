using LangProcessor.Domain.Postulates;

namespace LangProcessor.ConsoleApp.Services
{
    public interface IInputService
    {
        IPostulate ParseInput(string input);
    }
}
