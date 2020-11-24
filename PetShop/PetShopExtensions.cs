using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public static IEnumerable<TItem> FindWithMatchingSpecies<TItem>(this IEnumerable<TItem> items, Predicate<TItem> predicate)
    {
        return ((List<TItem>)items).FindAll(predicate);
    }
}