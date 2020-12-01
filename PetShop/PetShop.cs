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
                _petsInTheStore.ThatSatisfy(IsASpecies(Species.Mouse));

        public IEnumerable<Pet> AllCats()
            =>
                _petsInTheStore.ThatSatisfy(IsASpecies(Species.Cat));

        public IEnumerable<Pet> AllFemalePets()
            =>
                _petsInTheStore.ThatSatisfy(IsFemale);

        public IEnumerable<Pet> AllCatsOrDogs()
            =>
                _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Dog || pet.species == Species.Cat);

        public IEnumerable<Pet> AllPetsButNotMice()
            =>
                _petsInTheStore.ThatSatisfy(IsNotSpecies(Species.Mouse));


        public IEnumerable<Pet> AllMaleDogs()
            =>
                _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Dog && IsMale(pet));

        public IEnumerable<Pet> AllPetsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy(IsBornAfter(2010));

        public IEnumerable<Pet> AllDogsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
            =>
                _petsInTheStore.ThatSatisfy(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);

        private static Predicate<Pet> IsASpecies(Species species)
        {
            return pet => pet.species == species;
        }

        private bool IsFemale(Pet pet)
        {
            return pet.sex == Sex.Female;
        }

        private bool IsMale(Pet pet)
        {
            return pet.sex == Sex.Male;
        }

        private static Predicate<Pet> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        private static Predicate<Pet> IsNotSpecies(Species species)
        {
            return pet => pet.species != species;
        }
    }

}
