using System;
using FsCheck;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    class IntMultiplyTests
    {
        [PropertyTest]
        public void IntMultiplyIsAssociative(int a, int b, int c)
        {
            Assert.AreEqual(
                (a * b) * c,
                a * (b * c));
        }

        [PropertyTest]
        public void IntMultiplyIsCommutative(int a, int b)
        {
            Assert.AreEqual(
                a * b,
                b * a);
        }

        [PropertyTest]
        public void OneIsTheIdentityOfIntMultiply(int a)
        {
            var id = 1;

            Assert.AreEqual(
                a * id,
                a);

            Assert.AreEqual(
                id * a,
                a);
        }

        [PropertyTest]
        public Property DivideIsTheInverseOfIntMultiply(int a, int b)
        {
            Func<bool> property = () =>
                (a * b) / b == a;

            return property.When(b != 0);
        }

        [PropertyTest]
        public void MultiplyDistributesOverAdd(int a, int b, int c)
        {
            Assert.AreEqual(
                a * (b + c),
                (a * b) + (a * c));
        }
    }
}
