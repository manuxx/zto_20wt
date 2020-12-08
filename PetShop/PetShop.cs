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
            sortedPets.Sort((p1, p2) => p1.name.CompareTo(p2.name));
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
                _petsInTheStore.ThatSatisfy(new Alternative<Pet>(Pet.IsASpecies(Species.Dog), Pet.IsASpecies(Species.Cat)));

        public IEnumerable<Pet> AllPetsButNotMice()
            =>
                _petsInTheStore.ThatSatisfy(new Negation<Pet>(Pet.IsASpecies(Species.Mouse)));

        public IEnumerable<Pet> AllMaleDogs()
            =>
                _petsInTheStore.ThatSatisfy(new Conjunction<Pet>(Pet.IsASpecies(Species.Dog), Pet.IsMale()));

        public IEnumerable<Pet> AllDogsBornAfter2010()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog));

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
            =>
                _petsInTheStore.ThatSatisfy((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));

    }

    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> m_criteria1;
        private readonly Criteria<TItem> m_criteria2;

        public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            m_criteria1 = criteria1;
            m_criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return m_criteria1.IsSatisfiedBy(item) && m_criteria2.IsSatisfiedBy(item);
        }
    }
}
