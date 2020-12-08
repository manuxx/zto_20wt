namespace Training.DomainClasses
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> m_criteria1;
        private readonly Criteria<TItem> m_criteria2;

        public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            m_criteria1 = criteria1;
            m_criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return m_criteria1.IsSatisfiedBy(item) && m_criteria2.IsSatisfiedBy(item);
        }
    }

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

    public class Alternative<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> m_criterion1;
        private readonly Criteria<TItem> m_criterion2;

        public Alternative(Criteria<TItem> criterion1, Criteria<TItem> criterion2)
        {
            m_criterion1 = criterion1;
            m_criterion2 = criterion2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return m_criterion1.IsSatisfiedBy(item) || m_criterion2.IsSatisfiedBy(item);
        }
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T pet);
}