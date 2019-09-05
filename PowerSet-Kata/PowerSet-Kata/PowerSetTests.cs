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
        public void subsets_of_an_empty_set_is_the_empty_set()
        {
            var subsets = _powerSet.Subsets(new int[0]);

            Assert.Collection(subsets, set => Assert.Equal(new int[0], set));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(999)]
        public void subsets_of_a_single_element_are_the_empty_set_and_a_set_with_only_this_number(int element)
        {
            var subsets = _powerSet.Subsets(new[] { element });

            Assert.Collection(subsets,
                set => Assert.Equal(new int[0], set),
                set => Assert.Equal(new[] { element }, set));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(-1, 45)]
        public void subsets_of_two_elements(int first, int second)
        {
            var subsets = _powerSet.Subsets(new[] { first, second });

            Assert.Collection(subsets,
                set => Assert.Equal(new int[0], set),
                set => Assert.Equal(new[] { first }, set),
                set => Assert.Equal(new[] { second }, set),
                set => Assert.Equal(new[] { first, second }, set));
        }

        [Fact]
        public void subsets_of_three_elements()
        {
            var subsets = _powerSet.Subsets(new[] { 1, 2, 3 });

            Assert.Collection(subsets,
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
        public void subsets_of_three_letters()
        {
            var subsets = _powerSet.Subsets(new[] { 'a', 'b', 'c' });

            Assert.Collection(subsets,
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