using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class Alternative<TItem> : CompositeCriteria<TItem>
    {
        public Alternative(params Criteria<TItem>[] criterias)
        {
            _criterias = criterias;
        }
        

        public override bool IsSatisfiedBy(TItem item)
        {
            foreach (var criteria in _criterias)
            {
                if (criteria.IsSatisfiedBy(item))
                    return true;
            }

            return false;
        }
    }
}