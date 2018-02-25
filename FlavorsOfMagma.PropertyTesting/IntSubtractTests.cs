using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    class IntSubtractTests
    {
        [Ignore("Fails for most arguments")]
        public void IntSubtractIsAssociative(int a, int b, int c)
        {
            Assert.AreEqual(
                (a - b) - c,
                a - (b - c));
        }

        [Ignore("Fails for most arguments")]
        public void IntSubtractIsCommutative(int a, int b)
        {
            Assert.AreEqual(
                a - b,
                b - a);
        }

        [PropertyTest]
        public void ZeroIsTheRightIdentityOfIntSubtract(int a)
        {
            var id = 0;

            Assert.AreEqual(
                a - id,
                a);
        }

        [Ignore("Fails for most arguments")]
        public void ZeroIsTheLeftIdentityOfIntSubtract(int a)
        {
            var id = 0;

            Assert.AreEqual(
                id - a,
                a);
        }

        [PropertyTest]
        public void AdditionIsTheInverseOfIntSubtract(int a, int b)
        {
            Assert.AreEqual(
                (a - b) + b,
                a);
        }
    }
}
