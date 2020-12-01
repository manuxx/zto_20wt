namespace Training.DomainClasses
{
    public class IsMaleCriteria : PetShopExtensions.ICriteria<Pet>
    {
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == Sex.Male;
        }
    }
}