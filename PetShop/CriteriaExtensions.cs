namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria, Criteria<TItem> other)
        {
            return new Conjunction<TItem>(criteria, other);
        }

        public static Criteria<TItem> Or(this Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
        {
            return new Alternative<TItem>(firstCriteria, secondCriteria);
        }
    }
}