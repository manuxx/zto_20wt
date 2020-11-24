using System.Collections.Generic;

static internal class PetShopExtensions
{
<<<<<<< HEAD
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
=======
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
>>>>>>> main
        }
    }
}