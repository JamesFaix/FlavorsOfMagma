using System.Linq;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class SetUnionTests
    {
        //All of these tests fail if a null sequence is passed to Union

        [PropertyTest]
        public void SetUnionIsAssociative(int[] a, int[] b, int[] c)
        {
            CollectionAssert.AreEquivalent(
                a.Union(b).Union(c),
                a.Union(b.Union(c)));
        }

        [PropertyTest]
        public void SetUnionIsCommutative(int[] a, int[]b)
        {
            CollectionAssert.AreEquivalent(
                a.Union(b),
                b.Union(a));
        }

        [PropertyTest]
        public void EmptySetIsTheIdentityOfSetUnion(int[] a)
        {
            var id =  new int[0];

            var setA = a.Distinct();

            CollectionAssert.AreEquivalent(
                setA.Union(id),
                setA);

            CollectionAssert.AreEquivalent(
                id.Union(setA),
                setA);
        }

        [Ignore("Fails for most arguments")]
        public void SetUnionDistributesOverIntersect(int[] a, int[] b, int[] c)
        {
            CollectionAssert.AreEquivalent(
                a.Union(b.Intersect(c)),
                a.Intersect(b).Union(a.Intersect(c)));
        }
    }
}
