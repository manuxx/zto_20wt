public static partial class PetShopExtensions
{
    public interface ICriteria<T>
    {
        bool IsSatisfiedBy(T pet);
    }
}