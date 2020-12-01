using System;
using Training.DomainClasses;

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

public class SpeciesCriteria : ICriteria<Pet>
{
    private readonly Species _species;

    public SpeciesCriteria(Species species)
    {
        _species = species;
    }

    public bool IsSatisfiedBy(Pet pet)
    {
        return pet.species == _species;
    }
}

internal class AnonymousCriteria<TItem> : ICriteria<TItem>
{
    private readonly Predicate<TItem> _predicate;

    public AnonymousCriteria(Predicate<TItem> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(TItem item) => _predicate(item);
}
