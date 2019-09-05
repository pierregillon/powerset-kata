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

            var element = set.First();
            var rest = set.Skip(1).ToArray();
            var sets = Get(rest);

            return Enumerable.Empty<int[]>()
                .Union(new[] { new[] { element } })
                .Union(sets)
                .Union(sets.Union(element))
                .OrderBy(x => x.Length)
                .ThenBy(x => x.FirstOrDefault())
                .ToArray();
        }
    }

    public static class SetExtensions
    {
        public static int[][] Union(this int[][] sets, int element)
        {
            var query =
                from set in sets
                where set.Any()
                let unionSet = set.Union(new[] { element }).OrderBy(x => x)
                select unionSet.ToArray();

            return query.ToArray();
        }
    }
}