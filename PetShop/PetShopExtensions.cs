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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Predicate<TItem> predicate)
    {
        return items.ThatSatisfy(new AnonymousCriteria<TItem>(predicate));
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
}