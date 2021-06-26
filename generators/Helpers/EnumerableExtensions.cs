using System.Collections.Generic;

namespace Exercism.CSharp.Helpers
{
    internal static class EnumerableExtensions
    {
        public static SortedSet<TSource> ToSortedSet<TSource>(this IEnumerable<TSource> source)
            => new SortedSet<TSource>(source);
    }
}