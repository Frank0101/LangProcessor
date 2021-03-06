using System.Collections.Generic;

namespace LangProcessor.Domain.Models
{
    public record Term(string Value)
    {
        public Dictionary<string, string> Synonyms { get; } = new();
        public Dictionary<string, string> Types { get; } = new();
        public Dictionary<string, string> Instances { get; } = new();
    };
}
