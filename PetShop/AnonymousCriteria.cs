using System;

public class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _predicate;

    public AnonymousCriteria(Predicate<T> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(T pet)
    {
        return _predicate(pet);
    }
}