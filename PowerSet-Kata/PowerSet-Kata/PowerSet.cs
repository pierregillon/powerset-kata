using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerSet_Kata
{
    public class PowerSet
    {
        public T[][] Subsets<T>(T[] set)
        {
            return GetFromBinaryTable(set)
                .Select(x => x.ToArray())
                .OrderBy(x => x.Length)
                .ThenBy(x => x.FirstOrDefault())
                .ToArray();
        }

        private static IEnumerable<IEnumerable<T>> GetFromBinaryTable<T>(IReadOnlyList<T> set)
        {
            for (var binaryValue = 0; binaryValue < Math.Pow(2, set.Count); binaryValue++) {
                yield return GetElementsMatchingWithBinaryValue(set, binaryValue);
            }
        }

        private static IEnumerable<T> GetElementsMatchingWithBinaryValue<T>(IReadOnlyList<T> set, int binaryValue)
        {
            for (var i = 0; i < set.Count; i++) {
                var pow = (int) Math.Pow(2, i);
                if ((pow & binaryValue) == pow) {
                    yield return set[i];
                }
            }
        }
    }
}