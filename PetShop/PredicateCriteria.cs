using System;

public class PredicateCriteria<TItem> : ICriteria<TItem>
{
    private readonly Predicate<TItem> _predicate;

    public PredicateCriteria(Predicate<TItem> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _predicate(item);
    }
}