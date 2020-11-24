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

    public static IEnumerable<TItem> AllThatPassCondition<TItem>(this IEnumerable<TItem> items,
        Func<TItem, bool> conditionFunc)
    {
        foreach (var item in items)
        {
            if(conditionFunc(item))
                yield return item;
        }
    }
}