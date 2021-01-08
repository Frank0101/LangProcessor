using LangProcessor.Domain.Models;

namespace LangProcessor.Domain.Postulates
{
    public record ExistPostulate(string Value) : IPostulate
    {
        public void Teach(Knowledge knowledge)
        {
            knowledge.Terms.GetOrAdd(Value, () => new Term(Value));
        }
    }
}
