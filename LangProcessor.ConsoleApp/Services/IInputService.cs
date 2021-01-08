using LangProcessor.Domain.Models.Postulates;

namespace LangProcessor.ConsoleApp.Services
{
    public interface IInputService
    {
        public IPostulate ParseInput(string input);
    }
}
