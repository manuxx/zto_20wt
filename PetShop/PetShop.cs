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
<<<<<<< Updated upstream
                _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Dog || pet.species == Species.Cat));
=======
                _petsInTheStore.ThatSatisfy(new Alternative(TItem.IsASpecies(Species.Dog),  TItem.IsASpecies(Species.Cat)));
>>>>>>> Stashed changes

        public IEnumerable<TItem> AllPetsButNotMice()
            =>
<<<<<<< Updated upstream
                _petsInTheStore.ThatSatisfy(Pet.IsNotASpecies(Species.Mouse));
=======
                _petsInTheStore.ThatSatisfy(new Negation<TItem>(TItem.IsASpecies(Species.Mouse)));
>>>>>>> Stashed changes

        public IEnumerable<TItem> AllMaleDogs()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Dog && pet.sex == Sex.Male));


        public IEnumerable<TItem> AllDogsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog));

        public IEnumerable<TItem> AllPetsBornAfter2011OrRabbits()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));

    }

    public class Alternative : Criteria<TItem>
    {
        private Criteria<TItem> _criteria1;
        private Criteria<TItem> _criteria2;

        public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            _criteria2 = criteria2;
            _criteria1 = criteria1;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }
}
