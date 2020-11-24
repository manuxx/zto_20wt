using System.Collections.Generic;

internal static class PetShopExtensions
{
    public static IEnumerable<T> Immutabilize<T>(this IList<T> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}