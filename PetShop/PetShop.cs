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
            return _petsInTheStore;
        }

        public void Add(Pet newPet)
        {
            foreach (var _pet in _petsInTheStore)
            {
                if (_pet == newPet)
                {
                    return;
                }
            }

            _petsInTheStore.Add(newPet);
        }
    }
}