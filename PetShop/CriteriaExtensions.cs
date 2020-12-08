namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> And<T>(this Criteria<T> criteria, Criteria<T> other)
        {
            return new Alternative<T>(criteria, other);
        }
    }
}