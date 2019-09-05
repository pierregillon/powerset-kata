using System.Linq;
using Xunit;

namespace PowerSet_Kata
{
    public class PowerSetTests
    {
        private readonly PowerSet _powerset;

        public PowerSetTests()
        {
            _powerset = new PowerSet();
        }

        [Fact]
        public void power_set_of_0_element_returns_empty_set()
        {
            var sets = _powerset.Get(new int[0]);

            Assert.Single(sets);
            Assert.Equal(new int[0], sets.Single());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(999)]
        public void power_set_of_1_element_returns_empty_set_and_a_set_with_only_this_element(int element)
        {
            var sets = _powerset.Get(new[] { element });

            Assert.Equal(2, sets.Length);
            Assert.Equal(new int[0], sets.First());
            Assert.Equal(new[] { element }, sets.Last());
        }
    }
}