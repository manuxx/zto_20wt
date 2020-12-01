namespace Training.DomainClasses
{
    public class FemaleCriteria : Criteria<Pet>
    {
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == Sex.Female;
        }
    }
}