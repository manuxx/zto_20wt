using System;

internal class AnonymousCriteria<TItem> : ICriteria<TItem>
{
    private readonly Predicate<TItem> _predicate;

    public AnonymousCriteria(Predicate<TItem> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(TItem item) => _predicate(item);
}