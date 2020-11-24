using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public partial class PetShop
    {
        public class ReadOnly<TItem> : IEnumerable<TItem>
        {
            private readonly IEnumerable<TItem> _item;

            public ReadOnly(IList<TItem> item)
            {
                _item = item;
            }

            public IEnumerator<TItem> GetEnumerator()
            {
                return _item.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}