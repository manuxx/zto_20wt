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

        public static Criteria<Pet> IsASpecies(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BornAfterYearCriteria(year);
        }

        public static Predicate<Pet> IsNotSpecies(Species species)
        {
            return pet => pet.species != species;
        }

        public static Criteria<Pet> IsFemale()
        {
            return new FemaleCriteria();
        }
    }

    public class FemaleCriteria : Criteria<Pet>
    {
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == Sex.Female;
        }
    }

    public class BornAfterYearCriteria : Criteria<Pet>
    {
        private readonly int _year;

        public BornAfterYearCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > _year;
        }
    }
}