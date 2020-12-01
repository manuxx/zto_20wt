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

    public static IEnumerable<TItem> FindPets<TItem>(this IEnumerable<TItem> petsInTheStore, Predicate<TItem> predicate)
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