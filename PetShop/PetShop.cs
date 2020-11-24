using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

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
    }
}