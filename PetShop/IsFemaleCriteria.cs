namespace Training.DomainClasses
{
    public class IsFemaleCriteria : PetShopExtensions.ICriteria<Pet>
    {
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == Sex.Female;
        }
    }
}