namespace Training.DomainClasses
{
    public abstract class SpeciesCriteria : Criteria<Pet>
    {
        protected readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }
        abstract public bool IsSatisfiedBy(Pet pet);
    }
    public class SpeciesEqualCriteria : SpeciesCriteria
    {
        public SpeciesEqualCriteria(Species species) : base(species) { }
        public override bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == _species;
        }
    }

    public class SpeciesNotEqualCriteria : SpeciesCriteria
    {
        public SpeciesNotEqualCriteria(Species species) : base(species) { }
        public override bool IsSatisfiedBy(Pet pet)
        {
            return pet.species != _species;
        }
    }
}