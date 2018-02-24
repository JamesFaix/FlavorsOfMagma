using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class StringConcatTests
    {
        [PropertyTest]
        public void StringConcatIsAssociative(string str1, string str2, string str3)
        {
            Assert.AreEqual(
                (str1 + str2) + str3,
                str1 + (str2 + str3));
        }

        [PropertyTest]
        public void StringConcatIsCommutative(string str1, string str2)
        {
            //FAILS

            Assert.AreEqual(
                str1 + str2,
                str2 + str1);
        }

        [PropertyTest]
        public void EmptyStringIsTheIdentityOfStringConcat(string str)
        {
            //Fails for NULL

            var identity = "";

            Assert.AreEqual(
                str + identity,
                str);

            Assert.AreEqual(
                identity + str,
                str);
        }

        [PropertyTest]
        public void NullIsTheIdentityOfStringConcat(string str)
        {
            //Fails for NULL

            string identity = null;

            Assert.AreEqual(
                str + identity,
                str);

            Assert.AreEqual(
                identity + str,
                str);
        }

        [PropertyTest]
        public void RemoveFromEndIsTheInverseOfStringConcat(string str1, string str2)
        {
            //Fails because null is coerced into "" by concat

            Assert.AreEqual(
                (str1 + str2).RemoveFromEnd(str2),
                str1);
        }
    }
}
