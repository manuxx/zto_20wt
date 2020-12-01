using System;
using System.Collections.Generic;

static public class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> ThatSatisfies<TItem>(this IEnumerable<TItem> items, Predicate<TItem> predicate)
    {
        return items.ThatSatisfies(new AnonymusCriteria<TItem>(predicate));
    }

    public static IEnumerable<TItem> ThatSatisfies<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var i in items)
        {
            if (criteria.IsSatisfiedBy(i))
            {
                yield return i;
            }
        }
    }
}