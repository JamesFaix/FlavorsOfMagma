using System.Linq;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class SequenceConcatTests
    {
        [PropertyTest]
        public void SequenceConcatIsAssociative(int[] seq1, int[] seq2, int[] seq3)
        {
            Assert.AreEqual(
                seq1.Concat(seq2).Concat(seq3),
                seq1.Concat(seq2.Concat(seq3)));
        }

        [PropertyTest]
        public void SequenceConcatIsCommutative(int[] seq1, int[] seq2)
        {
            //FAILS

            Assert.AreEqual(
                seq1.Concat(seq2),
                seq2.Concat(seq1));
        }

        [PropertyTest]
        public void EmptySequenceIsTheIdentityOfSequenceConcat(int[] seq)
        {
            var identity = new int[0];

            Assert.AreEqual(
                seq.Concat(identity),
                seq);

            Assert.AreEqual(
                identity.Concat(seq),
                seq);
        }

        [PropertyTest]
        public void RemoveFromEndIsTheInverseOfSequenceConcat(int[] seq1, int[] seq2)
        {
            Assert.AreEqual(
                seq1.Concat(seq2).RemoveFromEnd(seq2),
                seq1);
        }
    }
}
