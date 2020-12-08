namespace Training.DomainClasses
{
    public static class CriteriaExtension
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
        {
            return new Conjuction<TItem>(firstCriteria, secondCriteria);
        }

        public static Criteria<TItem> Or<TItem>(this Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
        {
            return new Alternative<TItem>(firstCriteria, secondCriteria);
        }
    }
}