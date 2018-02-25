using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    class IntSubtractTests
    {
        [PropertyTest]
        public void IntSubtractIsAssociative(int a, int b, int c)
        {
            //Fails

            Assert.AreEqual(
                (a - b) - c,
                a - (b - c));
        }

        [PropertyTest]
        public void IntSubtractIsCommutative(int a, int b)
        {
            //Fails

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

        [PropertyTest]
        public void ZeroIsTheLeftIdentityOfIntSubtract(int a)
        {
            //Fails

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
