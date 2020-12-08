using System;
using System.Reflection;
using Training.DomainClasses;

namespace Training.Spec
{
    public class Where<Item>
    {
        private Func<Item, Object> _selector;


        public static CriteriaBuilder<TSelector> hasAn<TSelector>(Func<Item, TSelector> selector)
        {
            return new CriteriaBuilder<TSelector>(selector);
        }

        public class CriteriaBuilder<TSelector>
        {
            private Func<Item, TSelector> _selector;
            public CriteriaBuilder(Func<Item, TSelector> selector)
            {
                _selector = selector;
            }

            public Criteria<Item> EqualTo(TSelector mouse)
            {
                return new AnonymousCriteria<Item>(p => _selector(p).Equals(mouse));
            }
        }
        
        

    }


}