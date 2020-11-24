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

    public static IEnumerable<Pet> AllPetsBySex(this IEnumerable<Pet> pets, Sex sex)
    {
        foreach (var pet in pets)
        {
            if (pet.sex == sex)
            {
                yield return pet;
            }
        }
    }
    public static IEnumerable<Pet> AllPetsBySpecie(this IEnumerable<Pet> pets, Species specie)
    {
        foreach (var pet in pets)
        {
            if (pet.species == specie)
            {
                yield return pet;
            }
        }
    }

    public static IEnumerable<Pet> AllPetsWithoutSpecie(this IEnumerable<Pet> pets, Species specie)
    {
        foreach (var pet in pets)
        {
            if (pet.species != specie)
            {
                yield return pet;
            }
        }
    }

    public static IEnumerable<Pet> AllPetsBornAfter(this IEnumerable<Pet> pets, int year)
    {
        foreach (var pet in pets)
        {
            if (pet.yearOfBirth > year)
            {
                yield return pet;
            }
        }
    }
}