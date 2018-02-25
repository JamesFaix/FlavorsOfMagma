using System;
using FsCheck;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;

namespace FlavorsOfMagma.PropertyTesting
{
    class FloatAddTests
    {
        private const float comparisonDelta = 0.00001f;

        [PropertyTest]
        public Property FloatAddIsUsuallyAssociative(float a, float b, float c)
        {
            Func<bool> property = () => 
                ((a + b) + c).IsCloseTo(a + (b + c), comparisonDelta);

            return property.When((a+b).IsFiniteNumber() && (a+b+c).IsFiniteNumber());
        }

        [PropertyTest]
        public void FloatAddIsCommutative(float a, float b)
        {
            Assert.AreEqual(
                a + b,
                b + a);
        }

        [PropertyTest]
        public void ZeroIsTheIdentityOfFloatAdd(float a)
        {
            var id = 0f;

            Assert.AreEqual(
                a + id,
                a);

            Assert.AreEqual(
                id + a,
                a);
        }

        [PropertyTest]
        public Property SubtractionIsUsuallyTheInverseOfFloatAdd(float a, float b)
        {
            Console.WriteLine($"a: {a}, b: {b}");

            Func<bool> property = () => 
                ((a + b) - b).IsCloseTo(a, comparisonDelta);

            return property.When(a.IsFiniteNumber() && b.IsFiniteNumber() && (a+b).IsFiniteNumber());
        }
    }
}
