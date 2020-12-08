using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly IEnumerable<Criteria<TItem>> _criterias;


        public Conjunction(params Criteria<TItem>[] criterias)
        {
            _criterias = criterias;
        }


        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criteria in _criterias)
            {
                if (!criteria.IsSatisfiedBy(item))
                    return false;
            }

            return true;
        }
    }
}