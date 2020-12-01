using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static partial class PetShopExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> pets, Predicate<TItem> predicate)
    {
        return pets.ThatSatisfy(new AnonymousCriteria<TItem>(predicate));
    }
    
    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> pets, ICriteria<TItem> criteria)
    {
        foreach (var pet in pets)
        {
            if (criteria.IsSatisfiedBy(pet))
            {
                yield return pet;
            }
        }
    }
}

