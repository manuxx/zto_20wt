using System;
using System.Collections;
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
            return new ReadOnlySet(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.name == newPet.name)
                {
                    return;
                }
            }

            _petsInTheStore.Add(newPet);
        }
    }

    public class ReadOnlySet : IEnumerable<Pet>
    {
        private IList<Pet> pets;

        public ReadOnlySet(IList<Pet> petsInTheStore)
        {
            this.pets = petsInTheStore;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            return pets.OneAtATime().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}