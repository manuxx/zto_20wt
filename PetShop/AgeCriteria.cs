namespace Training.DomainClasses
{
    public class AgeCriteria : ICriteria<Pet>
    {
        private readonly int _minimumYear;

        public AgeCriteria(int minimumYear)
        {
            _minimumYear = minimumYear;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > _minimumYear;
        }
    }
}