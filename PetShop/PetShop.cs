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


        public IEnumerable<Pet> AllCats() => _petsInTheStore.That(p => p.species == Species.Cat);
        public IEnumerable<Pet> AllMice() => _petsInTheStore.That(p => p.species == Species.Mouse);
        public IEnumerable<Pet> AllFemalePets() => _petsInTheStore.That(p => p.sex == Sex.Female);
        public IEnumerable<Pet> AllCatsOrDogs() => _petsInTheStore.That(p => p.species.In(Species.Cat, Species.Dog));
        public IEnumerable<Pet> AllPetsButNotMice() => _petsInTheStore.That(p => p.species != Species.Mouse);
        public IEnumerable<Pet> AllPetsBornAfter2010() => _petsInTheStore.That(p => p.yearOfBirth > 2010);
        public IEnumerable<Pet> AllDogsBornAfter2010() => _petsInTheStore.That(p => p.species == Species.Dog && p.yearOfBirth > 2010);
        public IEnumerable<Pet> AllMaleDogs() => _petsInTheStore.That(p => p.sex == Sex.Male && p.species == Species.Dog);
        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits() => _petsInTheStore.That(p => p.yearOfBirth > 2011 || p.species == Species.Rabbit);
    }
}
