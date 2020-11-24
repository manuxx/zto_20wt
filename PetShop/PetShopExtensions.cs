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

    public static IEnumerable<Pet> AllOfSameKind(this IEnumerable<Pet> pets, IEnumerable<Species> species)
    {
        foreach (var pet in pets)
        {
            foreach (var s in species)
            {
                if (pet.species == s)
                    yield return pet;
            }
        }
    }

    public static IEnumerable<Pet> AllButNotThisKind(this IEnumerable<Pet> pets, Species species)
    {
        foreach (var pet in pets)
        {
            if (pet.species != species)
                yield return pet;
        }
    }

    public static IEnumerable<Pet> AllSameSex(this IEnumerable<Pet> pets, Sex sex)
    {
        foreach (var pet in pets)
        {
            if (pet.sex == sex)
                yield return pet;
        }
    }

    public static IEnumerable<Pet> AllBornAfter(this IEnumerable<Pet> pets, int minYear)
    {
        foreach (var pet in pets)
        {
            if (pet.yearOfBirth > minYear)
                yield return pet;
        }
    }
}