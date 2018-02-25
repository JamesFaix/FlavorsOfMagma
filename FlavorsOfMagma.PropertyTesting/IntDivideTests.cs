using System;
using FsCheck;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    class IntDivideTests
    {
        [PropertyTest]
        public void IntDivideIsAssociative(int a, int b, int c)
        {
            //Fails

            Assert.AreEqual(
                (a / b) / c,
                a / (b / c));
        }

        [PropertyTest]
        public void IntDivideIsCommutative(int a, int b)
        {
            //Fails

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

        [PropertyTest]
        public void OneIsTheLeftIdentityOfIntDivide(int a)
        {
            //Fails

            var id = 1;

            Assert.AreEqual(
                id / a,
                a);
        }

        [PropertyTest]
        public Property MultiplicationIsTheInverseOfIntDivide(int a, int b)
        {
            //Fails because integer division rounds

            Func<bool> property = () => (a / b) * b == a;

            return property.When(b != 0);
        }
    }
}
