using System.Collections.Generic;
using Training.DomainClasses;

static internal class PetShopExtensions
{
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}