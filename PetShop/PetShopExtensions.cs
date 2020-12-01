using System;
using System.Collections.Generic;
using Training.DomainClasses;

static internal class PetShopExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<Pet> ThatSatisfy(this IList<Pet> petsInTheStore, Predicate<Pet> predicate)
    {
        foreach (var pet in petsInTheStore)
        {
            if (predicate(pet))
            {
                yield return pet;
            }
        }
    }
}