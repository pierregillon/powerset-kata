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
        public void power_set_of_0_element_return_empty_set()
        {
            var sets = _powerset.Get(new int[0]);

            Assert.Single(sets);
            Assert.Equal(new int[0], sets.Single());
        }
    }
}
