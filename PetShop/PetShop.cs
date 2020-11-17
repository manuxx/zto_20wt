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
            return _petsInTheStore;
        }

        public void Add(Pet newPet)
        {
            if (!IsPetAlreadyInTheStore(newPet))
            {
                _petsInTheStore.Add(newPet);
            }
        }

        private bool IsPetAlreadyInTheStore(Pet newPet)
        {
            return _petsInTheStore.Contains(newPet);
        }
    }
}