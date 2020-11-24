using System.Collections.Generic;
using Training.DomainClasses;

static internal class PetShopExtentions
{
    public static IEnumerable<TItem> ToImmutableCollection<TItem>(this IList<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}