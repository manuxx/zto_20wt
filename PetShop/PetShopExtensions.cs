using System.Collections.Generic;
using Training.DomainClasses;

internal static class PetShopExtensions
{
    public static IEnumerable<T> Immutabilize<T>(this IList<T> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}