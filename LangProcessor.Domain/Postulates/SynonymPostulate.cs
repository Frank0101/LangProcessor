using LangProcessor.Domain.Models;

namespace LangProcessor.Domain.Postulates
{
    public record SynonymPostulate(string Value1, string Value2) : IPostulate
    {
        public void Teach(Knowledge knowledge)
        {
            if (Value1 != Value2)
            {
                var term1 = knowledge.Terms.GetOrAdd(Value1, () => new Term(Value1));
                term1.Synonyms.TryAdd(Value2, Value2);

                var term2 = knowledge.Terms.GetOrAdd(Value2, () => new Term(Value2));
                term2.Synonyms.TryAdd(Value1, Value1);
            }
            else
            {
                knowledge.Terms.GetOrAdd(Value1, () => new Term(Value1));
            }
        }
    }
}
