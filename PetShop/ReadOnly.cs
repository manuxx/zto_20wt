using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnly<TItem> : IEnumerable<TItem>
    {
        private IEnumerable<TItem> _items;
        public ReadOnly(IList<TItem> items)
        {
            _items = items;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}