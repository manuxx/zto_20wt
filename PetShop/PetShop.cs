using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnly<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            foreach (var pet in _petsInTheStore)
                if (pet.name == newPet.name)
                    return;
            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> sortedPets = new List<Pet>(_petsInTheStore);
            sortedPets.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return sortedPets;
        }

        public IEnumerable<Pet> AllMice()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.species == Species.Mouse));

        public IEnumerable<Pet> AllCats()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.species == Species.Cat));

        public IEnumerable<Pet> AllFemalePets()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.sex == Sex.Female));

        public IEnumerable<Pet> AllCatsOrDogs()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.species == Species.Dog || pet.species == Species.Cat));

        public IEnumerable<Pet> AllPetsButNotMice()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.species != Species.Mouse));

        public IEnumerable<Pet> AllMaleDogs()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.species == Species.Dog && pet.sex == Sex.Male));

        public IEnumerable<Pet> AllPetsBornAfter2010()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.yearOfBirth > 2010));

        public IEnumerable<Pet> AllDogsBornAfter2010()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog));

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
            =>
                PetShopExtensions.ThatSatisfy(_petsInTheStore, (pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));

    }

}
