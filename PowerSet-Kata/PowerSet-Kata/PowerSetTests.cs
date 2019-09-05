using Xunit;

namespace PowerSet_Kata
{
    public class PowerSetTests
    {
        private readonly PowerSet _powerSet;

        public PowerSetTests()
        {
            _powerSet = new PowerSet();
        }

        [Fact]
        public void power_set_of_0_element_returns_empty_set()
        {
            var sets = _powerSet.Get(new int[0]);

            Assert.Collection(sets, set => Assert.Equal(new int[0], set));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(999)]
        public void power_set_of_1_element_returns_empty_set_and_a_set_with_only_this_element(int element)
        {
            var sets = _powerSet.Get(new[] { element });

            Assert.Collection(sets,
                set => Assert.Equal(new int[0], set),
                set => Assert.Equal(new[] { element }, set));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(-1, 45)]
        public void power_set_of_2_elements(int first, int second)
        {
            var sets = _powerSet.Get(new[] { first, second });

            Assert.Collection(sets,
                set => Assert.Equal(new int[0], set),
                set => Assert.Equal(new[] { first }, set),
                set => Assert.Equal(new[] { second }, set),
                set => Assert.Equal(new[] { first, second }, set));
        }

        [Fact]
        public void power_set_of_3_elements()
        {
            var sets = _powerSet.Get(new[] { 1, 2, 3});

            Assert.Collection(sets,
                set => Assert.Equal(new int[0], set),
                set => Assert.Equal(new[] { 1 }, set),
                set => Assert.Equal(new[] { 2 }, set),
                set => Assert.Equal(new[] { 3 }, set),
                set => Assert.Equal(new[] { 1, 2 }, set),
                set => Assert.Equal(new[] { 1, 3 }, set),
                set => Assert.Equal(new[] { 2, 3 }, set),
                set => Assert.Equal(new[] { 1, 2, 3 }, set)
            );
        }

        [Fact]
        public void power_set_of_3_letters()
        {
            var sets = _powerSet.Get(new[] { 'a', 'b', 'c' });

            Assert.Collection(sets,
                set => Assert.Equal(new char[0], set),
                set => Assert.Equal(new[] { 'a' }, set),
                set => Assert.Equal(new[] { 'b' }, set),
                set => Assert.Equal(new[] { 'c' }, set),
                set => Assert.Equal(new[] { 'a', 'b' }, set),
                set => Assert.Equal(new[] { 'a', 'c' }, set),
                set => Assert.Equal(new[] { 'b', 'c' }, set),
                set => Assert.Equal(new[] { 'a', 'b', 'c' }, set)
            );
        }
    }
}