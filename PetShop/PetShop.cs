using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> sortedPets = new List<Pet>(_petsInTheStore);
            sortedPets.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return sortedPets;
        }

        public IEnumerable<Pet> AllMice()
            =>
                _petsInTheStore.ThatSatisfy(Pet.IsASpecies(Species.Mouse));

        public IEnumerable<Pet> AllPetsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2010));

        public IEnumerable<Pet> AllCats()
            =>
                _petsInTheStore.ThatSatisfy(Pet.IsASpecies(Species.Cat));

        public IEnumerable<Pet> AllFemalePets()
            =>
                _petsInTheStore.ThatSatisfy(Pet.IsFemale());

        public IEnumerable<Pet> AllCatsOrDogs()
            =>
<<<<<<< Updated upstream
                _petsInTheStore.ThatSatisfy(new Alternative(Pet.IsASpecies(Species.Dog),  Pet.IsASpecies(Species.Cat)));
=======
                _petsInTheStore.ThatSatisfy(new Alternative(TItem.IsASpecies(Species.Dog),  TItem.IsASpecies(Species.Cat)));

>>>>>>> Stashed changes

        public IEnumerable<Pet> AllPetsButNotMice()
            =>
<<<<<<< Updated upstream
                _petsInTheStore.ThatSatisfy(new Negation<Pet>(Pet.IsASpecies(Species.Mouse)));
=======

                _petsInTheStore.ThatSatisfy(new Negation<TItem>(TItem.IsASpecies(Species.Mouse)));
>>>>>>> Stashed changes

        public IEnumerable<Pet> AllMaleDogs()
            =>
                _petsInTheStore.ThatSatisfy(new Conjunction<TItem>(TItem.IsASpecies(Species.Dog), new Negation<TItem>(TItem.IsFemale())));


        public IEnumerable<Pet> AllDogsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog));

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));

    }

<<<<<<< Updated upstream
=======
    public class Conjunction<T> : Criteria<TItem>
    {
        private Criteria<TItem> _criteria1;
        private Criteria<TItem> _criteria2;

        public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            _criteria2 = criteria2;
            _criteria1 = criteria1;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
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
>>>>>>> Stashed changes
}
