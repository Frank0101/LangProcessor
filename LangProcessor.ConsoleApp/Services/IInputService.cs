using LangProcessor.Domain.Models.Postulates;

namespace LangProcessor.ConsoleApp.Services
{
    public interface IInputService
    {
        IPostulate ParseInput(string input);
    }
}
