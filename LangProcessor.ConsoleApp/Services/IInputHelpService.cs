using System.Collections.Generic;

namespace LangProcessor.ConsoleApp.Services
{
    public interface IInputHelpService
    {
        IEnumerable<string> GetInputHelpMessages();
    }
}
