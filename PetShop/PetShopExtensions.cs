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

    public static IEnumerable<TItem> AllWhich<TItem>(this IEnumerable<TItem> items, Predicate<TItem> predicate)
    {
        foreach (var i in items)
        {
            if (predicate(i))
            {
                yield return i;
            }
        }
    }
}