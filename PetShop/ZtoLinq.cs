using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class ZtoLinq
    {
        public static IEnumerable<TItem> That<TItem>(this IEnumerable<TItem> col, Predicate<TItem> condition)
        {
            foreach (var item in col)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }

        private static bool In<TItem>(this TItem searched, IEnumerable<TItem> items) where TItem : class
        {
            foreach (var item in items)
            {
                if (item == searched)
                    return true;
            }

            return false;
        }

        public static bool In<TItem>(this TItem searched, params TItem[] items) where TItem : class => searched.In(items as IEnumerable<TItem>);
    }
}