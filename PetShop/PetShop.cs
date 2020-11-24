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
            {
                if (pet.name == newPet.name)
                {
                    return;
                }
            }

            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in this.AllPets())
            {
                if (pet.species.Equals(Species.Cat))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> sortedPets = new List<Pet>(this.AllPets());

            sortedPets.Sort((p1, p2) => p1.name.CompareTo(p2.name));

            return sortedPets;
        }

        public IEnumerable<Pet> AllMice() => this.AllPets().FindMatchedItems(p => p.species.Equals(Species.Mouse));

        public IEnumerable<Pet> AllFemalePets() => this.AllPets().FindMatchedItems(p => p.sex.Equals(Sex.Female));

        public IEnumerable<Pet> AllCatsOrDogs() => this.AllPets()
            .FindMatchedItems(p => (p.species.Equals(Species.Cat) || p.species.Equals(Species.Dog)));

        public IEnumerable<Pet> AllPetsButNotMice() => this.AllPets()
            .FindMatchedItems(p => !p.species.Equals(Species.Mouse));

        public IEnumerable<Pet> AllPetsBornAfter2010() => this.AllPets().FindMatchedItems(p => p.yearOfBirth > 2010);

        public IEnumerable<Pet> AllDogsBornAfter2010() => this.AllPets().FindMatchedItems(p => p.species.Equals(Species.Dog) && p.yearOfBirth > 2010);

        public IEnumerable<Pet> AllMaleDogs() => this.AllPets().FindMatchedItems(p => p.species.Equals(Species.Dog) && p.sex.Equals(Sex.Male));

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits() => this.AllPets().FindMatchedItems(p => p.species.Equals(Species.Rabbit) || p.yearOfBirth > 2011);
    }
}