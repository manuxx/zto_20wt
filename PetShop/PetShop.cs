using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<TItem> _petsInTheStore;

        public PetShop(IList<TItem> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<TItem> AllPets()
        {
            return new ReadOnly<TItem>(_petsInTheStore);
        }

        public void Add(TItem newItem)
        {
            foreach (var pet in _petsInTheStore)
                if (pet.name == newItem.name)
                    return;
            _petsInTheStore.Add(newItem);
        }

        public IEnumerable<TItem> AllPetsSortedByName()
        {
            List<TItem> sortedPets = new List<TItem>(_petsInTheStore);
            sortedPets.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return sortedPets;
        }

        public IEnumerable<TItem> AllMice()
            =>
                _petsInTheStore.ThatSatisfy(TItem.IsASpecies(Species.Mouse));

        public IEnumerable<TItem> AllPetsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy(TItem.IsBornAfter(2010));

        public IEnumerable<TItem> AllCats()
            =>
                _petsInTheStore.ThatSatisfy(TItem.IsASpecies(Species.Cat));

        public IEnumerable<TItem> AllFemalePets()
            =>
                _petsInTheStore.ThatSatisfy(TItem.IsFemale());

        public IEnumerable<TItem> AllCatsOrDogs()
            =>
                _petsInTheStore.ThatSatisfy(TItem.IsASpecies(Species.Dog).Or(TItem.IsASpecies(Species.Cat)));

        public IEnumerable<TItem> AllPetsButNotMice()
            =>
                _petsInTheStore.ThatSatisfy(new Negation<TItem>(TItem.IsASpecies(Species.Mouse)));

        public IEnumerable<TItem> AllMaleDogs()
            =>
                _petsInTheStore.ThatSatisfy(TItem.IsASpecies(Species.Dog).And(TItem.IsMale()));


        public IEnumerable<TItem> AllDogsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy((TItem.IsBornAfter(2010).And(TItem.IsASpecies(Species.Dog))));

        public IEnumerable<TItem> AllPetsBornAfter2011OrRabbits()
            =>
                _petsInTheStore.ThatSatisfy((TItem.IsBornAfter(2011).Or(TItem.IsASpecies(Species.Rabbit))));

    }
}
