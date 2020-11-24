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

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> sortedPetsByName = new List<Pet>(_petsInTheStore);
            sortedPetsByName.Sort((p1,p2) => p1.name.CompareTo(p2.name));

            return sortedPetsByName;
        }

        public class PetNameComparer : Comparer<Pet>
        {
            public override int Compare(Pet x, Pet y)
            {
                return x.name.CompareTo(y.name);
            }
        }
    }
}