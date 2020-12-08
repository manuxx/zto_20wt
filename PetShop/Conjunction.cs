using System.Collections.Generic;

namespace Training.DomainClasses
{
    public abstract class CompositeCriteria<TItem> : Criteria<TItem>
    {
        protected IEnumerable<Criteria<TItem>> _criterias;

        public CompositeCriteria(params Criteria<TItem>[] criterias)
        {
            _criterias = criterias;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Conjunction<TItem> : CompositeCriteria<TItem>
    {
        public Conjunction(params Criteria<TItem>[] criterias) : base(criterias)
        {
        }


        public override bool IsSatisfiedBy(TItem item)
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