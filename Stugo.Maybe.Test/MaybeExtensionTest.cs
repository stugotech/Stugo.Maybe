using System;
using Xunit;

namespace Stugo.Maybe.Test
{
    public class MaybeExtensionTest
    {
        [Fact]
        public void FirstOrNothing_returns_the_first_element_in_a_list()
        {
            var list = new int[] { 1, 2, 3, 4 };

            var first = list.FirstOrNothing();

            Assert.Equal(true, first.HasValue);
            Assert.Equal(1, first.Value);
        }


        [Fact]
        public void FirstOrNothing_returns_nothing_for_an_empty_list()
        {
            var list = new int[] { };

            var first = list.FirstOrNothing();

            Assert.Equal(false, first.HasValue);
        }


        [Fact]
        public void SingleOrNothing_returns_the_only_element_in_a_list()
        {
            var list = new int[] { 1 };

            var first = list.SingleOrNothing();

            Assert.Equal(true, first.HasValue);
            Assert.Equal(1, first.Value);
        }


        [Fact]
        public void SingleOrNothing_throws_InvalidOperationException_for_a_multi_value_list()
        {
            var list = new int[] { 1, 2 };

            Assert.Throws<InvalidOperationException>(() => list.SingleOrNothing());
        }


        [Fact]
        public void SingleOrNothing_returns_nothing_for_an_empty_list()
        {
            var list = new int[] { };

            var first = list.SingleOrNothing();

            Assert.Equal(false, first.HasValue);
        }
    }
}
