using System;

namespace Training.DomainClasses
{
    public class AnonymousCriteria<T> : ICriteria<T>
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
}
