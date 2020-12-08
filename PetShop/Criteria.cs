public interface Criteria<T>
{
    bool IsSatisfiedBy(T pet);
}

public class Negation<T> : Criteria<T>
{
    private readonly Criteria<T> _baseCriteria;
    public Negation(Criteria<T> criteria)
    {
        _baseCriteria = criteria;
    }

    public bool IsSatisfiedBy(T pet)
    {
        return !_baseCriteria.IsSatisfiedBy(pet);
    }
}
