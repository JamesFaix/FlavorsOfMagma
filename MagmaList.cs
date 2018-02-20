using System.Collections.Generic;
using System.Linq;

namespace FlavorsOfMagma
{
    class MagmaList<T> : IMagma<MagmaList<T>>
    {
        private readonly T[] _Array;

        public MagmaList(IEnumerable<T> elements)
        {
            _Array = elements.ToArray();
        }

        #region Main members

        public IEnumerable<T> Elements =>
            _Array.AsEnumerable();

        public static MagmaList<T> Concat(MagmaList<T> a, MagmaList<T> b) =>
            new MagmaList<T>(a.Elements.Concat(b.Elements));

        #endregion

        #region IMagma

        public MagmaList<T> Invoke(MagmaList<T> a, MagmaList<T> b) =>
            Concat(a, b);

        #endregion
    }
}
