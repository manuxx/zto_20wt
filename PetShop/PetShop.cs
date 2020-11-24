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
            return _petsInTheStore.AllOfSameKind(new List<Species>() {Species.Cat});
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.AllOfSameKind(new List<Species>() { Species.Mouse });
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.AllSameSex(Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.AllOfSameKind(new List<Species>() { Species.Dog , Species.Cat});
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllButNotThisKind(Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllBornAfter(2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            IEnumerable<Pet> dogs = _petsInTheStore.AllOfSameKind(new List<Species>() { Species.Dog });
            return dogs.AllBornAfter(2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            IEnumerable<Pet> dogs = _petsInTheStore.AllOfSameKind(new List<Species>() { Species.Dog });
            return dogs.AllSameSex(Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            var young = _petsInTheStore.AllBornAfter(2011);
            var youngNotRabbits = young.AllButNotThisKind(Species.Rabbit);
            var allRabbits = _petsInTheStore.AllOfSameKind(new List<Species>() {Species.Rabbit});
            List<Pet> allTogether = new List<Pet>(allRabbits);
            foreach (var youngNotRabbit in youngNotRabbits)
                allTogether.Add(youngNotRabbit);
            return allTogether;
        }
    }

}
