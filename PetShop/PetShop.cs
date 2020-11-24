using System;
using System.Collections;
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
            return new ReadOnlySet<Pet>(_petsInTheStore);
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
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> list = new List<Pet>(_petsInTheStore);
            list.Sort((p1, p2) => p1.name.CompareTo(p2.name));
            return list;
        }
    }

    public class ReadOnlySet<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> pets;
        public ReadOnlySet(IEnumerable<T> petsInTheStore)
        {
            this.pets = petsInTheStore;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}