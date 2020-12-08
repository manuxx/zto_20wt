using System;
using Training.DomainClasses;

namespace Training.Spec
{
    internal class CriteriaBuilder<TItem, TSelected>
    {
        private readonly Func<TItem, TSelected> m_selector;

        public CriteriaBuilder(Func<TItem, TSelected> selector)
        {
            m_selector = selector;
        }

        public Criteria<TItem> EqualTo(TSelected value)
        {
            return new AnonymousCriteria<TItem>(item => m_selector(item).Equals(value));
        }
    }

    internal class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TSelected> HasAn<TSelected>(Func<TItem, TSelected> selector)
        {
            return new CriteriaBuilder<TItem, TSelected>(selector);
        }
    }
}