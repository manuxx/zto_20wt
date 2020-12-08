using System;

namespace Training.DomainClasses
{
    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(Criteria<TItem> criteriaLeft, Criteria<TItem> criteriaRight) : base(criteriaLeft, criteriaRight)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteriaLeft.IsSatisfiedBy(item) && _criteriaRight.IsSatisfiedBy(item);
        }
    }
}