using System;

namespace FlavorsOfMagma
{
    static class Program
    {
        static void Main()
        {            
            //Combine MagmaList

            var list1 = new MagmaList<int>(new[] { 1, 2, 3 });
            var list2 = new MagmaList<int>(new[] { 4, 3, 2 });

            var list3 = list1.Invoke(list1, list2);
            var list4 = MagmaList<int>.Concat(list1, list2);

            Console.WriteLine($"{nameof(list3)} is [{string.Join(", ", list3)}]");
            Console.WriteLine($"{nameof(list4)} is [{string.Join(", ", list4)}]");
            Console.Read();


            //Combine MagmaSet

            var set1 = new MagmaSet<int>(new[] { 1, 2, 3 });
            var set2 = new MagmaSet<int>(new[] { 4, 3, 2 });
            
            var set3 = set1.Invoke(set1, set2);
            var set4 = MagmaSet<int>.Union(set1, set2);
            var set5 = MagmaSet<int>.Intersect(set1, set2);

            Console.WriteLine($"{nameof(set3)} is [{string.Join(", ", set3)}]");
            Console.WriteLine($"{nameof(set4)} is [{string.Join(", ", set4)}]");
            Console.WriteLine($"{nameof(set5)} is [{string.Join(", ", set5)}]");
            Console.Read();


            //Combine MagmaSet2

            var set6 = new MagmaSet2<int>(new[] { 1, 2, 3 });
            var set7 = new MagmaSet2<int>(new[] { 4, 3, 2 });
            
            var set8 = set6.Union.Invoke(set6, set7);
            var set9 = set6.Intersect.Invoke(set6, set7);

            Console.WriteLine($"{nameof(set8)} is [{string.Join(", ", set8.Elements)}]");
            Console.WriteLine($"{nameof(set9)} is [{string.Join(", ", set9.Elements)}]");
            Console.Read();


            //Use delegate magma

            MagmaDelegate<int> m = Math.Min;
            var min = m(4, 10);

            m = Math.Max;
            var max = m(4, 10);

            Console.WriteLine($"{nameof(min)} is {min}");
            Console.WriteLine($"{nameof(max)} is {max}");
        }
    }
}
