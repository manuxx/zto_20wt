namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria, Criteria<TItem> other)
        {
            return new Conjunction<TItem>(criteria, other);
        }
    }
}