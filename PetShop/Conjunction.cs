﻿namespace Training.DomainClasses
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteriaLeft;
        private readonly Criteria<TItem> _criteriaRight;
        public Conjunction(Criteria<TItem> criteriaLeft, Criteria<TItem> criteriaRight)
        {
            _criteriaLeft = criteriaLeft;
            _criteriaRight = criteriaRight;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteriaLeft.IsSatisfiedBy(item) && _criteriaRight.IsSatisfiedBy(item);
        }
    }
}