using System.Linq;

namespace PowerSet_Kata
{
    public class PowerSet
    {
        public T[][] Get<T>(T[] set)
        {
            if (set.Any() == false) {
                return new[] { new T[0] };
            }

            var element = set.First();
            var rest = set.Skip(1).ToArray();
            var sets = Get(rest);

            return Enumerable.Empty<T[]>()
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
        public static T[][] Union<T>(this T[][] sets, T element)
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