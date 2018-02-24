using System.Linq;
using NUnit.Framework;
using PropertyTest = FsCheck.NUnit.PropertyAttribute;
 
namespace FlavorsOfMagma.PropertyTesting
{
    public class TestClass
    {
        [PropertyTest(QuietOnSuccess = true)]
        public void ConcatIsAssociative(int[] xs, int[] ys, int[] zs)
        {
            Assert.AreEqual(
                xs.Concat(ys).Concat(zs),
                xs.Concat(ys.Concat(zs)));
        }
    }
}
