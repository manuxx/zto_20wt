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
        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.species == Species.Cat || x.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.species == Species.Dog && x.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.species == Species.Dog && x.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllThatPassCondition(x => x.species == Species.Rabbit || x.yearOfBirth > 2011);
        }
    }

}
