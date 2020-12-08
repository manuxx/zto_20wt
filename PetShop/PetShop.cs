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
                _petsInTheStore.ThatSatisfy(Pet.IsASpecies(Species.Dog).Or(Pet.IsASpecies(Species.Cat)));

        public IEnumerable<Pet> AllPetsButNotMice()
            =>
                _petsInTheStore.ThatSatisfy(new Negation<Pet>(Pet.IsASpecies(Species.Mouse)));

        public IEnumerable<Pet> AllMaleDogs()
            =>
                _petsInTheStore.ThatSatisfy( new Conjunction<Pet>(Pet.IsASpecies(Species.Dog), Pet.IsMale()));


        public IEnumerable<Pet> AllDogsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2010).And(Pet.IsASpecies(Species.Dog)));

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));

    }

    public class Conjunction<T> : Criteria<T>
    {
        private readonly Criteria<T> _criteria;
        private readonly Criteria<T> _otherCriteria;

        public Conjunction(Criteria<T> criteria, Criteria<T> otherCriteria)
        {
            _criteria = criteria;
            _otherCriteria = otherCriteria;
        }

        public bool IsSatisfiedBy(T subject)
        {
            return _criteria.IsSatisfiedBy(subject) && _otherCriteria.IsSatisfiedBy(subject);
        }
    }

    public class Alternative<T> : Criteria<T>
    {
        public Criteria<T>[] Criteria { get; }

        public Alternative(params Criteria<T>[] criteria)
        {
            Criteria = criteria;
        }

        public bool IsSatisfiedBy(T subject)
        {
            foreach (var criteria in Criteria)
            {
                if (criteria.IsSatisfiedBy(subject))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public static class CriteriaExtensions
    {
        public static Criteria<T> And<T>(this Criteria<T> criteria, Criteria<T> other)
        {
            return new Conjunction<T>(criteria, other);
        }
        
        public static Criteria<T> Or<T>(this Criteria<T> criteria, Criteria<T> other)
        {
            return new Alternative<T>(criteria, other);
        }
    }
}
