using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class BooleanOrTests
    {
        [PropertyTest]
        public void BooleanOrIsAssociative(bool a, bool b, bool c)
        {
            Assert.AreEqual(
                (a || b) || c,
                a || (b || c));
        }

        [PropertyTest]
        public void BooleanOrIsCommutative(bool a, bool b)
        {
            Assert.AreEqual(
                a || b,
                b || a);
        }

        [PropertyTest]
        public void FalseIsTheIdentityOfBooleanOr(bool a)
        {
            var id = false;

            Assert.AreEqual(
                a || id,
                a);

            Assert.AreEqual(
                id || a,
                a);
        }

        [PropertyTest]
        public void BooleanOrDistributesOverAnd(bool a, bool b, bool c)
        {
            Assert.AreEqual(
                a || (b && c),
                (a || b) && (a || c));
        }
    }
}
