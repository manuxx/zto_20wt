using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        public IEnumerable<Pet> AllMice()
        {
            foreach (var pet in this.AllPets())
            {
                if (pet.species.Equals(Species.Mouse))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            foreach (var pet in this.AllPets())
            {
                if (pet.sex.Equals(Sex.Female))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            foreach (var pet in this.AllPets())
            {
                if (pet.species.Equals(Species.Cat) || pet.species.Equals(Species.Dog))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            foreach (var pet in this.AllPets())
            {
                if (!pet.species.Equals(Species.Mouse))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            foreach (var pet in this.AllPets())
            {
                if (pet.yearOfBirth > 2010)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            foreach (var pet in this.AllPetsBornAfter2010())
            {
                if (pet.species.Equals(Species.Dog))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            foreach (var pet in this.AllPets())
            {
                if (pet.species.Equals(Species.Dog) && pet.sex.Equals(Sex.Male))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            foreach (var pet in this.AllPets())
            {
                if (pet.species.Equals(Species.Rabbit) || pet.yearOfBirth > 2011)
                {
                    yield return pet;
                }
            }
        }
    }
}