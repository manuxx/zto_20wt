using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class PetShopExtensions
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> petsInTheStore)
        {
            foreach (var pet in petsInTheStore)
            {
                yield return pet;
            }
        }
    }
}