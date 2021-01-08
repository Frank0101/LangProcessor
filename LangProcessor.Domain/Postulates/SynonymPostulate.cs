using LangProcessor.Domain.Models;

namespace LangProcessor.Domain.Postulates
{
    public record SynonymPostulate(string Value1, string Value2) : IPostulate
    {
        public void Teach(Knowledge knowledge)
        {
            knowledge.Terms.Add(new Term(Value1));
            knowledge.Terms.Add(new Term(Value2));
        }
    }
}
