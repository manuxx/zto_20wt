using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<TItem> : IEnumerable<TItem>
    {
        private readonly IEnumerable<TItem> _item;
        public ReadOnlySet(IList<TItem> itemInTheStore)
        {
            _item = itemInTheStore;
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