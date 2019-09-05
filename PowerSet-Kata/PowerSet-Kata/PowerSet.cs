using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerSet_Kata
{
    public class PowerSet
    {
        public T[][] Subsets<T>(T[] set)
        {
            var results = new List<List<T>>();
            for (int binaryIndex = 0; binaryIndex < Math.Pow(2, set.Length); binaryIndex++) {
                var result = new List<T>();
                for (int i = 0; i < set.Length; i++) {
                    if (((int) Math.Pow(2, i) & binaryIndex) == (int) Math.Pow(2, i)) {
                        result.Add(set[i]);
                    }
                }

                results.Add(result);
            }

            return results
                .Select(x => x.ToArray())
                .OrderBy(x => x.Length)
                .ThenBy(x => x.FirstOrDefault())
                .ToArray();
        }
    }
}