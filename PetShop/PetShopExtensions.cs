using System;
using System.Collections.Generic;

static internal class PetShopExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> petsInTheStore, Predicate<TItem> predicate)
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