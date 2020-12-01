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
                PetShopExtensions.FindPets(this, pet => pet.species == Species.Mouse, _petsInTheStore);

        public IEnumerable<Pet> AllCats()
            =>
                PetShopExtensions.FindPets(this, pet => pet.species == Species.Cat, _petsInTheStore);

        public IEnumerable<Pet> AllFemalePets()
            =>
                PetShopExtensions.FindPets(this, pet => pet.sex == Sex.Female, _petsInTheStore);

        public IEnumerable<Pet> AllCatsOrDogs()
            =>
                PetShopExtensions.FindPets(this, pet => pet.species == Species.Dog || pet.species == Species.Cat, _petsInTheStore);

        public IEnumerable<Pet> AllPetsButNotMice()
            =>
                PetShopExtensions.FindPets(this, pet => pet.species != Species.Mouse, _petsInTheStore);

        public IEnumerable<Pet> AllMaleDogs()
            =>
                PetShopExtensions.FindPets(this, pet => pet.species == Species.Dog && pet.sex == Sex.Male, _petsInTheStore);

        public IEnumerable<Pet> AllPetsBornAfter2010()
            =>
                PetShopExtensions.FindPets(this, pet => pet.yearOfBirth > 2010, _petsInTheStore);

        public IEnumerable<Pet> AllDogsBornAfter2010()
            =>
                PetShopExtensions.FindPets(this, pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog, _petsInTheStore);

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
            =>
                PetShopExtensions.FindPets(this, pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit, _petsInTheStore);

    }

}
