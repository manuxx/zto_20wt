using System;
using System.Collections;
using System.Collections.Generic;
using Training.DomainClasses;

namespace PetShop
{
    public class PetNameComparer : IComparer<Pet>
    {
        public int Compare(Pet x, Pet y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            return string.Compare(x.name, y.name, StringComparison.Ordinal);
        }
    }
}
