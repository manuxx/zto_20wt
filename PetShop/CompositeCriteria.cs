namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> And<T>(this Criteria<T> criteria, Criteria<T> other)
        {
            return new Conjunction<T>(criteria, other);
        }
        
        public static Criteria<T> Or<T>(this Criteria<T> criteria, Criteria<T> other)
        {
            return new Alternative<T>(criteria, other);
        }
    }

    public class Alternative<T> : CompositeCriteria<T>
    {
        public Alternative(Criteria<T> left, Criteria<T> right) : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T subject)
        {
            return _left.IsSatisfiedBy(subject) || _right.IsSatisfiedBy(subject);
        }
    }

    public class Conjunction<T> : CompositeCriteria<T>
    {
        public Conjunction(Criteria<T> left, Criteria<T> right) : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T subject)
        {
            return _left.IsSatisfiedBy(subject) && _right.IsSatisfiedBy(subject);
        }
    }

    public abstract class CompositeCriteria<T> : Criteria<T>
    {
        protected Criteria<T> _left;
        protected Criteria<T> _right;

        protected CompositeCriteria(Criteria<T> left, Criteria<T> right)
        {
            _left = left;
            _right = right;
        }

        public abstract bool IsSatisfiedBy(T subject);
    }
}