using System;
using System.Collections.Generic;

namespace LangProcessor.Domain
{
    public static class DictionaryExtensions
    {
        public static TV GetOrAdd<TK, TV>(this Dictionary<TK, TV> dict, TK key, Func<TV> valueFactory) where TK : notnull
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }

            var value = valueFactory();
            dict.Add(key, value);
            return value;
        }
    }
}
