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

        private IEnumerable<Pet> FindPets(Predicate<Pet> predicate)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (predicate(pet))
                {
                    yield return pet;
                }
            }
        }

        private static Predicate<Pet> IsSpecies(Species species)
        {
            return pet => pet.species == species;
        }

        private static Predicate<Pet> IsNotSpecies(Species species)
        {
            return pet => pet.species != species;
        }

        private static Predicate<Pet> IsFemale()
        {
            return pet => pet.sex == Sex.Female;
        }

        private static Predicate<Pet> IsMale()
        {
            return pet => pet.sex == Sex.Male;
        }
        private static Predicate<Pet> BornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<Pet> AllMice()
            => FindPets(IsSpecies(Species.Mouse));

        public IEnumerable<Pet> AllCats()
            => FindPets(IsSpecies(Species.Cat));

        public IEnumerable<Pet> AllFemalePets()
            => FindPets(IsFemale());

        public IEnumerable<Pet> AllCatsOrDogs()
            => FindPets(pet => pet.species == Species.Dog || pet.species == Species.Cat);

        public IEnumerable<Pet> AllPetsButNotMice()
            => FindPets(IsNotSpecies(Species.Mouse));


        public IEnumerable<Pet> AllMaleDogs()
            => FindPets(pet => pet.species == Species.Dog && pet.sex == Sex.Male);

        public IEnumerable<Pet> AllPetsBornAfter2010()
            => FindPets(BornAfter(2010));
        
        public IEnumerable<Pet> AllDogsBornAfter2010()
            => FindPets(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
            => FindPets(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);

    }

}
