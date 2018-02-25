using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class SetIntersectTests
    {
        //All of these test fail if a null sequence is passed to Intersect

        [PropertyTest]
        public void SetIntersectIsAssociative(int[] a, int[] b, int[] c)
        {
            CollectionAssert.AreEquivalent(
                a.Intersect(b).Intersect(c),
                a.Intersect(b.Intersect(c)));
        }

        [PropertyTest]
        public void SetIntersectIsCommutative(int[] a, int[] b)
        {
            CollectionAssert.AreEquivalent(
                a.Intersect(b),
                b.Intersect(a));
        }

        private static byte[] EverythingSet = Enumerable.Range(0, 256).Select(n => (byte) n).ToArray();

        [PropertyTest]
        public void EverythingSetIsTheIdentityOfSetIntersect(byte[] a)
        {
            var id = EverythingSet;

            var setA = a.Distinct();

            CollectionAssert.AreEquivalent(
                setA.Intersect(id),
                setA);

            CollectionAssert.AreEquivalent(
                id.Intersect(setA),
                setA);
        }

        [PropertyTest]
        public void SetIntersectDistributesOverIntersect(int[] a, int[] b, int[] c)
        {
            CollectionAssert.AreEquivalent(
                a.Intersect(b.Intersect(c)),
                a.Intersect(b).Intersect(a.Intersect(c)));
        }
    }
}
