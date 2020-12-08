using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Training.DomainClasses;


public static class CriteriaExtensions
{
    public static Criteria<TItem> And<TItem>(this Criteria<TItem> lhsCriteria, Criteria<TItem> rhsCriteria)
    {
        return new Conjunction<TItem>(lhsCriteria, rhsCriteria);
    }
}
