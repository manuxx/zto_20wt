using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

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
            if (_petsInTheStore.Contains(newPet))
            {
                return;
            }
            _petsInTheStore.Add(newPet);
        }
    }
}