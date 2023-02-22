using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal static class ExtensionMethods
    {
        public static IEnumerable<TSource> SortLike<TSource, TKey>(this ICollection<TSource> source, IEnumerable<TKey> sortOrder)
        {
            var cloned = sortOrder.ToArray();
            var sourceArr = source.ToArray();
            Array.Sort(cloned, sourceArr);
            return sourceArr;
        }
    }
}
