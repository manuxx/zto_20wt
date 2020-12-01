namespace Training.DomainClasses
{
    public class BornAfterCriteria : PetShopExtensions.ICriteria<Pet>
    {
        private readonly int _after;

        public BornAfterCriteria(int after)
        {
            _after = after;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > _after;
        }
    }
}