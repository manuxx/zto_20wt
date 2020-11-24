using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class PetShopExtensions
    {
        public static IEnumerable<T> ToImmutableCollection<T>(this IEnumerable<T> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}