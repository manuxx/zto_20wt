namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> Or<T>(this Criteria<T> leftCriteria, Criteria<T> rightCriteria)
        {
            return new Alternative<T>(leftCriteria, rightCriteria);
        }

        public static Criteria<T> And<T>(this Criteria<T> leftCriteria, Criteria<T> rightCriteria)
        {
            return new Conjunction<T>(leftCriteria, rightCriteria);
        }
    }
}