namespace Training.DomainClasses
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem>[] _criteria;


        public Conjunction(params Criteria<TItem>[] criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criteria in _criteria)
            {
                if (!criteria.IsSatisfiedBy(item))
                    return false;
            }

            return true;
        }
    }

    public static class AndCriteriaExtension
    {
        public static Criteria<T> And<T>(this Criteria<T> leftCriteria, Criteria<T> rightCriteria)
        {
            return new Conjunction<T>(leftCriteria, rightCriteria);
        }
    }
}