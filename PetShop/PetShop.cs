using System;
using System.Collections;
using System.Collections.Generic;
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
            //return _petsInTheStore.OneAtATime();
            return new ReadOnlySet<Pet>(_petsInTheStore);
        }

        public class ReadOnlySet<TItem> : IEnumerable<TItem>
        {
            private readonly IEnumerable<TItem> _petsInTheStore;

            public ReadOnlySet(IList<TItem> petsInTheStore)
            {
                _petsInTheStore = petsInTheStore;
            }

            public IEnumerator<TItem> GetEnumerator()
            {
                return _petsInTheStore.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
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