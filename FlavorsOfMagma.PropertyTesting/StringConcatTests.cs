using System;
using FsCheck;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    public class StringConcatTests
    {
        [PropertyTest]
        public void StringConcatIsAssociative(string a, string b, string c)
        {
            Assert.AreEqual(
                (a + b) + c,
                a + (b + c));
        }

        [Ignore("Fails except when one argument is null or empty.")]
        public void StringConcatIsCommutative(string a, string b)
        {
            Assert.AreEqual(
                a + b,
                b + a);
        }

        [PropertyTest]
        public Property EmptyStringIsAnIdentityOfStringConcat(string a)
        {
            var id = "";

            Func<bool> property = () => 
                a + id == a && 
                id + a == a;

            return property.When(a != null);
        }

        [PropertyTest]
        public Property NullIsAnIdentityOfStringConcat(string a)
        {
            string id = null;

            Func<bool> property = () => 
                a + id == a && 
                id + a == a;

            return property.When(a != null);
        }

        [PropertyTest]
        public Property RemoveFromEndIsTheInverseOfStringConcat(string a, string b)
        {
            Func<bool> property = () => 
                (a + b).RemoveFromEnd(b) == a;

            return property.When(a != null);
        }
    }
}
