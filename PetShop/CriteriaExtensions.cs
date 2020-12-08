namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            return new Conjunction<TItem>(leftCriteria, rightCriteria);
        }

        public static Alternative<TItem> Or<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            return new Alternative<TItem>(leftCriteria, rightCriteria);
        }
    }
}