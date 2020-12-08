namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            return new Conjunction<TItem>(leftCriteria, rightCriteria);
        }

        public static Alternative<Pet> Or(this Criteria<Pet> leftCritera, Criteria<Pet> rightCriteria)
        {
            return new Alternative<Pet>(leftCritera,  rightCriteria);
        }
    }
}