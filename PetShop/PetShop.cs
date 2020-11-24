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

        public IEnumerable<Pet> AllCats() => AllWithMatchedPredicate(pet => pet.species == Species.Cat);
        public IEnumerable<Pet> AllMice() => AllWithMatchedPredicate(pet => pet.species == Species.Mouse);
        public IEnumerable<Pet> AllFemalePets() => AllWithMatchedPredicate(pet => pet.sex == Sex.Female);
        public IEnumerable<Pet> AllCatsOrDogs() => AllWithMatchedPredicate(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        public IEnumerable<Pet> AllPetsButNotMice() => AllWithMatchedPredicate(pet => pet.species != Species.Mouse);
        public IEnumerable<Pet> AllPetsBornAfter2010() => AllWithMatchedPredicate(pet => pet.yearOfBirth > 2010);
        public IEnumerable<Pet> AllDogsBornAfter2010() => AllWithMatchedPredicate(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        public IEnumerable<Pet> AllMaleDogs() => AllWithMatchedPredicate(pet => pet.sex == Sex.Male && pet.species == Species.Dog);
        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits() => AllWithMatchedPredicate(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        private IEnumerable<Pet> AllWithMatchedPredicate(Predicate<Pet> p)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (p.Invoke(pet))
                {
                    yield return pet;
                }
            }
        }
    }

}
