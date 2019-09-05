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

            var list = new Queue<int>(set);
            var element = list.Dequeue();
            var others = Get(list.ToArray());
            var finalSets = new List<int[]>(others) { new[] { element } };
            foreach (var otherSet in others) {
                if (otherSet.Any()) {
                    finalSets.Add(otherSet.Union(new []{ element }).ToArray());
                }
            }

            return finalSets.ToArray();
        }
    }
}