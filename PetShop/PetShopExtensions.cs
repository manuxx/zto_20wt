using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class PetShopExtensions
    {
        public static IEnumerable<TItem> ToImmutableCollection<TItem>(this IEnumerable<TItem> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}