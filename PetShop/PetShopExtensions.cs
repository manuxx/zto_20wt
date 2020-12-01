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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Predicate<TItem> func)
    {
        foreach (var item in items)
        {
            if (func(item))
            {
                yield return item;
            }
        }
    }
}