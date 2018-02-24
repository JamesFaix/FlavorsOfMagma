using System.Collections.Generic;
using System.Linq;

namespace FlavorsOfMagma.PropertyTesting
{
    static class Extensions
    {
        public static string RemoveFromEnd(this string source, string toRemove)
        {
            if (source == null)
            {
                return null;
            }
            if (toRemove == null)
            {
                return source;
            }

            var len = toRemove.Length;
            var matchStartIndex = source.Length - len;
            if (matchStartIndex >= 0)
            {
                var match = source.Substring(matchStartIndex, len);
                if (toRemove == match)
                {
                    return source.Substring(0, source.Length - len);
                }
            }
            return source;
        }

        public static IEnumerable<T> RemoveFromEnd<T>(this IEnumerable<T> source, IEnumerable<T> toRemove)
        {
            var sourceList = source.ToList();
            var toRemoveList = toRemove.ToList();
            var sourceLen = sourceList.Count;
            var toRemoveLen = toRemoveList.Count;

            var matchStartIndex = sourceLen - toRemoveLen;
            if (matchStartIndex >= 0)
            {
                var match = sourceList.Skip(matchStartIndex).Take(toRemoveLen);
                if (toRemoveList.SequenceEqual(match))
                {
                    return sourceList.Skip(0).Take(sourceLen - toRemoveLen);
                }
            }
            return sourceList.AsEnumerable();
        }
    }
}
