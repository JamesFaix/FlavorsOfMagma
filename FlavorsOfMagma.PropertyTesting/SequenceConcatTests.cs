using System.Linq;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class SequenceConcatTests
    {
        //All of these tests fail if a null sequence is passed into Concat

        [PropertyTest]
        public void SequenceConcatIsAssociative(int[] a, int[] b, int[] c)
        {
            CollectionAssert.AreEqual(
                a.Concat(b).Concat(c),
                a.Concat(b.Concat(c)));
        }

        [Ignore("Fails except when one argument is empty")]
        public void SequenceConcatIsCommutative(int[] a, int[] b)
        {
            CollectionAssert.AreEqual(
                a.Concat(b),
                b.Concat(a));
        }

        [PropertyTest]
        public void EmptySequenceIsTheIdentityOfSequenceConcat(int[] a)
        {
            var id = new int[0];

            CollectionAssert.AreEqual(
                a.Concat(id),
                a);

            CollectionAssert.AreEqual(
                id.Concat(a),
                a);
        }

        [PropertyTest]
        public void RemoveFromEndIsTheInverseOfSequenceConcat(int[] a, int[] b)
        {
            CollectionAssert.AreEqual(
                a.Concat(b).RemoveFromEnd(b),
                a);
        }
    }
}
