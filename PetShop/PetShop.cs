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

        public IList<Pet> AllCats()
        {
            IList<Pet> cats = new List<Pet>();
            foreach (Pet pet in _petsInTheStore)
            {
                if(pet.species == Species.Cat)
                    cats.Add(pet);
            }
            return cats;
        }

        public IList<Pet> AllPetsSortedByName()
        {
            var sortedPets = new List<Pet>(_petsInTheStore);
            sortedPets.Sort((a, b) => a.name.CompareTo(b.name));
            return sortedPets;
        }
    }
}