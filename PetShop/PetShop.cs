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
            if (!_petsInTheStore.Contains(newPet) && !IsNameAlreadyTaken(newPet.name))
            {
                this._petsInTheStore.Add(newPet);
            }
        }

        private bool IsNameAlreadyTaken(string name)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.name == name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}