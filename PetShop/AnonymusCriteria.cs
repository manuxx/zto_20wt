using System;

internal class AnonymusCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _predicate;

    public AnonymusCriteria(Predicate<T> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _predicate(item);
    }
}