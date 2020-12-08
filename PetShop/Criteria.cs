using System;
using Training.DomainClasses;

public interface Criteria<T>
{
    bool IsSatisfiedBy(T pet);
}