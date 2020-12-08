using System;

namespace Training.DomainClasses
{
    public class TItem : IEquatable<TItem>
    {
        public bool Equals(TItem other)
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
            return Equals((TItem) obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public static bool operator ==(TItem left, TItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TItem left, TItem right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static Criteria<TItem> IsASpecies(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<TItem> IsBornAfter(int year)
        {
            return new BornAfterYearCriteria(year);
        }

        public static Criteria<TItem> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Criteria<TItem> IsNotASpecies(Species species)
        {
            return new Negation<TItem>(IsASpecies(species));
        }

        public class SpeciesCriteria : Criteria<TItem>
        {
            private readonly Species _species;

            public SpeciesCriteria(Species species)
            {
                _species = species;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                return item.species == _species;
            }
        }
        public class SexCriteria : Criteria<TItem>
        {
            private readonly Sex _sex;

            public SexCriteria(Sex sex)
            {
                _sex = sex;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                return item.sex == _sex;
            }
        }
        public class BornAfterYearCriteria : Criteria<TItem>
        {
            private readonly int _year;

            public BornAfterYearCriteria(int year)
            {
                _year = year;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                return item.yearOfBirth > _year;
            }
        }
    }

    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteriaForNegation;

        public Negation(Criteria<TItem> criteriaForNegation)
        {
            _criteriaForNegation = criteriaForNegation;
            throw new NotImplementedException();
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return ! _criteriaForNegation.IsSatisfiedBy(item);
        }
    }
}