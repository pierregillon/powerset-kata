using System;
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

            return new[] {
                new int[0],
                new[] {set.First()}
            };
        }
    }
}