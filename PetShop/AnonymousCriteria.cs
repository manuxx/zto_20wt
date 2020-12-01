using System;

internal class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _predicate;

    public AnonymousCriteria(Predicate<T> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _predicate(item);
    }
}