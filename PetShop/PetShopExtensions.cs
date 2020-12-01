using System;
using System.Collections.Generic;


namespace Training.DomainClasses
{
    static internal class EnumerbaleExtensions
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Predicate<TItem> predicate)
        {
            return ThatSatisfy(items, new AnonymousCriteria<TItem>(predicate));
        }

        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.IsSatisfiedBy(item))
                {
                    yield return item;
                }
            }
        }
    }

    public interface Criteria<T>
    {
        bool IsSatisfiedBy(T item);
    }
}