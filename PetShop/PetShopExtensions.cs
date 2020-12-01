using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class PetShopExtensions
    {
        public static IEnumerable<Pet> FindPets(PetShop petShop, Predicate<Pet> predicate, IList<Pet> pets)
        {
            foreach (var pet in pets)
            {
                if (predicate(pet))
                {
                    yield return pet;
                }
            }
        }
    }
}