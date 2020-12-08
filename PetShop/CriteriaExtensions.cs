namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<Item> And<Item>(this Criteria<Item> leftCriteria, Criteria<Item> rigthCriteria)
        {
            return new Conjunction<Item>(leftCriteria, rigthCriteria);
        }
        public static Criteria<TItem> Or<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rigthCriteria)
        {
            return new Alternative<TItem>(leftCriteria, rigthCriteria);
        }
    }
}