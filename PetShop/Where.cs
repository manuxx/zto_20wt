using System;

namespace Training.DomainClasses
{
    public static class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TProperties> HasAn<TProperties>(Func<TItem, TProperties> propertySelector)
        {
            return new CriteriaBuilder<TItem, TProperties>(propertySelector);
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
                return new AnonymousCriteria<TItem>(p=>_propertySelector(p).Equals(value));
            }
        }
    }
}
