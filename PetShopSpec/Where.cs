using System;

namespace Training.Spec
{
    public class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TProperty> hasAn<TProperty>(Func<TItem, TProperty> propertySelector)
        {
            return new CriteriaBuilder<TItem, TProperty>(propertySelector);
        }
    }
}