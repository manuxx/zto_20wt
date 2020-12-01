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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> petsInTheStore, Predicate<TItem> predicate)
    {
        return petsInTheStore.ThatSatisfy(new AnonymousCriteria<TItem>(predicate));
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> petsInTheStore, Criteria<TItem> criteria)
    {
        foreach (var pet in petsInTheStore)
        {
            if (criteria.IsSatisfiedBy(pet))
            {
                yield return pet;
            }
        }
    }
}