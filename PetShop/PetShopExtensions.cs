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

    public static IEnumerable<Pet> ThatSatisfy(this IList<Pet> pets, Predicate<Pet> func)
    {
        foreach (var pet in pets)
        {
            if (func(pet))
            {
                yield return pet;
            }
        }
    }
}