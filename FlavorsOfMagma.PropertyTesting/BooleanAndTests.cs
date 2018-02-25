using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class BooleanAndTests
    {
        [PropertyTest]
        public void BooleanAndIsAssociative(bool a, bool b, bool c)
        {
            Assert.AreEqual(
                (a && b) && c,
                a && (b && c));
        }

        [PropertyTest]
        public void BooleanAndIsCommutative(bool a, bool b)
        {
            Assert.AreEqual(
                a && b,
                b && a);
        }

        [PropertyTest]
        public void TrueIsTheIdentityOfBooleanAnd(bool a)
        {
            var id = true;

            Assert.AreEqual(
                a && id,
                a);

            Assert.AreEqual(
                id && a,
                a);
        }
        
        [PropertyTest]
        public void BooleanAndDistributesOverOr(bool a, bool b, bool c)
        {
            Assert.AreEqual(
                a && (b || c),
                (a && b) || (a && c));
        }
    }
}
