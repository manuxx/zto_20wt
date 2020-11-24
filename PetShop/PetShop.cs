using System;
using System.Collections.Generic;
using System.Linq;

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
            return _petsInTheStore.AllPetsBySpecie(Species.Cat);
        }

        public IEnumerable<Pet> AllMice()
        {

            return _petsInTheStore.AllPetsBySpecie(Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.AllPetsBySex(Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.AllPetsBySpecie(Species.Cat)
                .Concat(_petsInTheStore.AllPetsBySpecie(Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllPetsWithoutSpecie(Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllPetsBornAfter(2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllPetsBySpecie(Species.Dog).AllPetsBornAfter(2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllPetsBySex(Sex.Male).AllPetsBySpecie(Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllPetsBornAfter(2011)
                .Concat(_petsInTheStore.AllPetsBySpecie(Species.Rabbit));
        }
    }

}
