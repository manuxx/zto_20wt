using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnly<TItem> : IEnumerable<TItem>
    {
        private readonly IEnumerable<TItem> _item;

        public ReadOnly(IEnumerable<TItem> item)
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