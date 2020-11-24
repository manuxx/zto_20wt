using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class PetShopExtensions
    {
        public static IEnumerable<T> ToImmutableCollection<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}