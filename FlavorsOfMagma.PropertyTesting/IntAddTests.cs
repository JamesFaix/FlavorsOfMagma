using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    class IntAddTests
    {
        [PropertyTest]
        public void IntAddIsAssociative(int a, int b, int c)
        {
            Assert.AreEqual(
                (a + b) + c,
                a + (b + c));
        }

        [PropertyTest]
        public void IntAddIsCommutative(int a, int b)
        {
            Assert.AreEqual(
                a + b,
                b + a);
        }

        [PropertyTest]
        public void ZeroIsTheIdentityOfIntAdd(int a)
        {
            var id = 0;

            Assert.AreEqual(
                a + id,
                a);

            Assert.AreEqual(
                id + a,
                a);
        }

        [PropertyTest]
        public void SubtractionIsTheInverseOfIntAdd(int a, int b)
        {
            Assert.AreEqual(
                (a + b) - b,
                a);
        }
    }
}
