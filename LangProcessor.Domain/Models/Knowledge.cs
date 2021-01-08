using System.Collections.Generic;
using System.Text.Json;

namespace LangProcessor.Domain.Models
{
    public record Knowledge
    {
        public Dictionary<string, Term> Terms { get; } = new();

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }
    }
}
