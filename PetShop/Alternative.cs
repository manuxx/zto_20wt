namespace Training.DomainClasses
{
    public class Alternative<TItem> : Criteria<TItem>
    {
        private Criteria<TItem>[] _criteria;


        public Alternative(params Criteria<TItem>[] criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criteria in _criteria)
            {
                if (criteria.IsSatisfiedBy(item))
                    return true;
            }

            return false;
        }
    }

    public static class OrCriteriaExtension
    {
        public static Criteria<T> Or<T>(this Criteria<T> leftCriteria, Criteria<T> rightCriteria)
        {
            return new Alternative<T>(leftCriteria, rightCriteria);
        }
    }
}