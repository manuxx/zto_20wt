using System;

namespace Training.Spec
{
    public class CriteriaBuilder<TItem, TProperties>
    {
        private readonly Func<TItem, TProperties> _propertySelector;

        public CriteriaBuilder(Func<TItem, TProperties> propertySelector)
        {
            _propertySelector = propertySelector;
        }
        public Criteria<TItem> EqualTo(TProperties propertyToCompare)
        {
            return new AnonymousCriteria<TItem>(p => _propertySelector(p).Equals(propertyToCompare));
        }
    }
}