using LangProcessor.Domain.Models;

namespace LangProcessor.Domain.Postulates
{
    public record TypePostulate(string Instance, string Type) : IPostulate
    {
        public void Teach(Knowledge knowledge)
        {
            if (Instance != Type)
            {
                var instanceTerm = knowledge.Terms.GetOrAdd(Instance, () => new Term(Instance));
                instanceTerm.Types.TryAdd(Type, Type);

                var typeTerm = knowledge.Terms.GetOrAdd(Type, () => new Term(Type));
                typeTerm.Instances.TryAdd(Instance, Instance);
            }
            else
            {
                knowledge.Terms.GetOrAdd(Instance, () => new Term(Instance));
            }
        }
    }
}
