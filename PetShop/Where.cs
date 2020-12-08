using System;
using Training.DomainClasses;

namespace Training.Spec
{
    public class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TProperty> HasAn<TProperty>(Func<TItem, TProperty> propertySelector)
        {
            return new CriteriaBuilder<TItem, TProperty>(propertySelector);
        }
    }

    public class CriteriaBuilder<TItem, TProperties>
    {
        private readonly Func<TItem, TProperties> _propertySelector;

        public CriteriaBuilder(Func<TItem, TProperties> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<TItem> EqualTo(TProperties value)
        {
            return new AnonymousCriteria<TItem>(p => _propertySelector(p).Equals(value));
        }
    }
}