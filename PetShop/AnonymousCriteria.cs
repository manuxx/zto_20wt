using System;

internal class AnonymousCriteria<TItem> : Criteria<TItem>
{
    private readonly Predicate<TItem> _predicate;

    public AnonymousCriteria(Predicate<TItem> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _predicate(item);
    }
}