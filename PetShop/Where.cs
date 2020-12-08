﻿using System;

namespace Training.DomainClasses
{
    public static class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TProperty> HasAn<TProperty>(Func<TItem, TProperty> propertySelector)
        {
            return new CriteriaBuilder<TItem, TProperty>(propertySelector);
        }

        public class CriteriaBuilder<TItem, TProperty>
        {
            private readonly Func<TItem, TProperty> _propertySelector;

            public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
            {
                _propertySelector = propertySelector;
            }
            public Criteria<TItem> EqualTo(TProperty value)
            {
                return new AnonymousCriteria<TItem>(p => _propertySelector(p).Equals(value));
            }
        }
    }
}