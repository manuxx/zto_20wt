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
}