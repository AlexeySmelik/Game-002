using System;
using System.Collections.Generic;

namespace GameModel
{
    public static class LinqExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var el in source)
                action(el);
        }
    }
}