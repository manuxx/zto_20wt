using System;
using Training.DomainClasses;

namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria4Negation;

        public Negation(Criteria<TItem> criteria4negation)
        {
            _criteria4Negation = criteria4negation;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteria4Negation.IsSatisfiedBy(item);
        }
    }

    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> m_criterion1;
        protected Criteria<TItem> m_criterion2;

        protected BinaryCriteria(Criteria<TItem> criterion1, Criteria<TItem> criterion2)
        {
            m_criterion1 = criterion1;
            m_criterion2 = criterion2;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return m_criterion1.IsSatisfiedBy(item) && m_criterion2.IsSatisfiedBy(item);
        }
    }

    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> criterion1, Criteria<TItem> criterion2) : base(criterion1, criterion2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return m_criterion1.IsSatisfiedBy(item) || m_criterion2.IsSatisfiedBy(item);
        }
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

public static class CriteriaExtensions
{
    public static Criteria<TItem> Or<TItem>(this Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
    {
        return new Alternative<TItem>(firstCriteria, secondCriteria);
    }

    public static Criteria<TItem> And<TItem>(this Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
    {
        return new Conjunction<TItem>(firstCriteria, secondCriteria);
    }
}