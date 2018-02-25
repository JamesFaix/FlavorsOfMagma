using System;
using FsCheck;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    class IntDivideTests
    {
        [Ignore("Fails for most arguments")]
        public void IntDivideIsAssociative(int a, int b, int c)
        {
            Assert.AreEqual(
                (a / b) / c,
                a / (b / c));
        }

        [Ignore("Fails for most arguments")]
        public void IntDivideIsCommutative(int a, int b)
        {
            Assert.AreEqual(
                a / b,
                b / a);
        }

        [PropertyTest]
        public void OneIsTheRightIdentityOfIntDivide(int a)
        {
            var id = 1;

            Assert.AreEqual(
                a / id,
                a);
        }

        [Ignore("Fails for most arguments")]
        public void OneIsTheLeftIdentityOfIntDivide(int a)
        {
            var id = 1;

            Assert.AreEqual(
                id / a,
                a);
        }

        [Ignore("Fails for most arguments because integer division rounds")]
        public Property MultiplicationIsTheInverseOfIntDivide(int a, int b)
        {
            Func<bool> property = () => 
                (a / b) * b == a;

            return property.When(b != 0);
        }
    }
}
