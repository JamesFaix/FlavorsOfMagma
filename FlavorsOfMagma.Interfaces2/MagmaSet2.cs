using System.Collections.Generic;
using System.Linq;

namespace FlavorsOfMagma.Interfaces
{
    class MagmaSet2<T>
    {
        private readonly T[] _Array;

        public MagmaSet2(IEnumerable<T> elements)
        {
            _Array = elements.Distinct().ToArray();
        }

        #region Main members

        public IEnumerable<T> Elements =>
            _Array.AsEnumerable();

        public IMagma<MagmaSet2<T>> Union { get; } = new SetUnion();

        public IMagma<MagmaSet2<T>> Intersect { get; } = new SetIntersect();

        #endregion

        public class SetUnion : IMagma<MagmaSet2<T>>
        {
            public MagmaSet2<T> Invoke(MagmaSet2<T> a, MagmaSet2<T> b) => new MagmaSet2<T>(a.Elements.Union(b.Elements));
        }

        public class SetIntersect : IMagma<MagmaSet2<T>>
        {
            public MagmaSet2<T> Invoke(MagmaSet2<T> a, MagmaSet2<T> b) => new MagmaSet2<T>(a.Elements.Intersect(b.Elements));
        }
    }
}
