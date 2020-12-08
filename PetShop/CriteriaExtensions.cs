namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            return new Conjunction<TItem>(leftCriteria, rightCriteria);
        }

        public static Criteria<TItem> Or(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            return new Alternative<TItem>(criteria1,  criteria2);
        }
    }
}