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
}