using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public bool Equals(Pet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pet) obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static ICriteria<Pet> IsASpeciesCriteria(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Predicate<Pet> IsFemale()
            => pet => pet.sex == Sex.Female;

        private static Predicate<Pet> IsMale()
            => pet => pet.sex == Sex.Male;

        public static Predicate<Pet> IsASpecies(Species species)
            => pet => pet.species == species;

        public static Predicate<Pet> IsNotASpecies(Species species)
            => pet => pet.species != species;

        public static Predicate<Pet> IsBornAfter(int year)
            => pet => pet.yearOfBirth > 2010;
    }

    public class SpeciesCriteria : ICriteria<Pet>
    {
        private readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == _species;
        }
    }
}