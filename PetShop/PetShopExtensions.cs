using System.Collections.Generic;

namespace Training.DomainClasses
{
    internal static class PetShopExtensions
    {
        public static IEnumerable<TItem> ToImmutableCollection<TItem>(this IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}