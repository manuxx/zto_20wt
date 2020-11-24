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
            sortedPets.Sort((p1, p2) => p1.name.CompareTo(p2.name));
            return sortedPets;
        }

        public IEnumerable<Pet> AllWhich(Func<Pet, bool> func)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (func(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllOfSpecies(params Species[] species)
        {
            return AllWhich(pet =>
            {
                foreach (var s in species)
                {
                    if (pet.species == s)
                    {
                        return true;
                    }
                }

                return false;
            });
        }


        public IEnumerable<Pet> AllBornAfter(int year)
        {
            return AllWhich(pet => pet.yearOfBirth > year);
        }

        public IEnumerable<Pet> AllCats()
        {
            return AllOfSpecies(Species.Cat);
        }

        public IEnumerable<Pet> AllMice()
        {
            return AllOfSpecies(Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllWhich(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllOfSpecies(Species.Cat, Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllWhich(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return AllBornAfter(2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllWhich(pet => (pet.yearOfBirth > 2010) && (pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllWhich(pet => (pet.sex == Sex.Male) && (pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return AllWhich(pet => (pet.yearOfBirth > 2011) || (pet.species == Species.Rabbit));
        }
    }

}
