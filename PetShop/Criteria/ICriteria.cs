namespace Training.DomainClasses
{
    public interface ICriteria<T>
    {
        bool IsSatisfiedBy(T pet);
    }
}
