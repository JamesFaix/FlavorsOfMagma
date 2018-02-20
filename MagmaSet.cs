using System.Collections.Generic;
using System.Linq;

namespace FlavorsOfMagma
{
    class MagmaSet<T> : IMagma<MagmaSet<T>>
    {
        private readonly T[] _Array;

        public MagmaSet(IEnumerable<T> elements)
        {
            _Array = elements.Distinct().ToArray();
        }

        #region Main members

        public IEnumerable<T> Elements =>
            _Array.AsEnumerable();

        public static MagmaSet<T> Union(MagmaSet<T> a, MagmaSet<T> b) =>
            new MagmaSet<T>(a.Elements.Union(b.Elements));

        public static MagmaSet<T> Intersect(MagmaSet<T> a, MagmaSet<T> b) =>
            new MagmaSet<T>(a.Elements.Intersect(b.Elements));

        #endregion

        #region IMagma

        public MagmaSet<T> Invoke(MagmaSet<T> a, MagmaSet<T> b) =>
            Union(a, b);             // Must pick one
         // Intersect(a, b);            Can't implement an interface twice

        #endregion
    }
}
