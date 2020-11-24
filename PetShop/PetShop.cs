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

        private IEnumerable<Pet> FilterPets(Func<Pet, bool> filter)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (filter(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllCats()
        {
            return FilterPets((pet => pet.species == Species.Cat));
        }

        public IEnumerable<Pet> AllMice()
        {
            return FilterPets((pet => pet.species == Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return FilterPets((pet => pet.sex == Sex.Female));
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return FilterPets((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return FilterPets((pet => pet.species != Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return FilterPets((pet => pet.yearOfBirth > 2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return FilterPets((pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return FilterPets((pet => pet.sex == Sex.Male && pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return FilterPets((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));
        }
    }

}
