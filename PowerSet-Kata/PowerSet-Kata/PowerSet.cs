using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerSet_Kata
{
    public class PowerSet
    {
        public int[][] Get(int[] set)
        {
            if (set.Any() == false) {
                return new[] { new int[0] };
            }

            var element = set.FirstOrDefault();
            var others = Get(set.Skip(1).ToArray());
            var finalSets = new List<int[]>(others) { new[] { element } };
            foreach (var otherSet in others) {
                if (otherSet.Any()) {
                    finalSets.Add(otherSet.Union(new[] { element }).OrderBy(x => x).ToArray());
                }
            }

            return finalSets
                .OrderBy(x => x.Length)
                .ThenBy(x => x.FirstOrDefault())
                .ToArray();
        }
    }
}