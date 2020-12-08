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

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Criteria<Pet> IsNotASpecies(Species species)
        {
            return new Negation<Pet>(IsASpecies(species));
        }

        public class SpeciesCriteria : Criteria<Pet>
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
        public class SexCriteria : Criteria<Pet>
        {
            private readonly Sex _sex;

            public SexCriteria(Sex sex)
            {
                _sex = sex;
            }

            public bool IsSatisfiedBy(Pet item)
            {
                return item.sex == _sex;
            }
        }
        public class BornAfterYearCriteria : Criteria<Pet>
        {
            private readonly int _year;

            public BornAfterYearCriteria(int year)
            {
                _year = year;
            }

            public bool IsSatisfiedBy(Pet item)
            {
                return item.yearOfBirth > _year;
            }
        }
    }

    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria4Negation;

        public Negation(Criteria<TItem> criteria4negation)
        {
            _criteria4Negation = criteria4negation;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return ! _criteria4Negation.IsSatisfiedBy(item);
        }
    }

    public class Alternative<TItem> : Criteria<TItem>
    {
        public readonly Criteria<TItem> _crieteria1;
        public readonly Criteria<TItem> _crieteria2;
        public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            _crieteria1 = criteria1;
            _crieteria2 = criteria2;
        }
        public bool IsSatisfiedBy(TItem pet)
        {
            return _crieteria1.IsSatisfiedBy(pet) || _crieteria2.IsSatisfiedBy(pet);
        }
    }
}