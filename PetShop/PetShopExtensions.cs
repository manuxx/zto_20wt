using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class PetShopExtensions
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}