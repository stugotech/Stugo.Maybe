using System;
using Xunit;

namespace Stugo.Maybe.Test
{
    public class MaybeTest
    {
        [Fact]
        public void It_can_use_a_value_type()
        {
            var maybe = new Maybe<int>(12);

            Assert.Equal(true, maybe.HasValue);
            Assert.Equal(12, maybe.Value);
        }


        [Fact]
        public void It_can_use_a_reference_type()
        {
            var value = new object();
            var maybe = new Maybe<object>(value);

            Assert.Equal(true, maybe.HasValue);
            Assert.Equal(value, maybe.Value);
        }


        [Fact]
        public void HasValue_returns_false_when_instance_has_no_value()
        {
            var maybe = new Maybe<object>();

            Assert.Equal(false, maybe.HasValue);
        }


        [Fact]
        public void HasValue_returns_true_when_instance_has_a_value()
        {
            var value = new object();
            var maybe = new Maybe<object>(value);

            Assert.Equal(true, maybe.HasValue);
        }


        [Fact]
        public void Value_returns_the_value_when_instance_has_a_value()
        {
            var value = new object();
            var maybe = new Maybe<object>(value);

            Assert.Equal(true, maybe.HasValue);
            Assert.Equal(value, maybe.Value);
        }


        [Fact]
        public void Value_throws_InvalidOperationException_when_instance_has_no_value()
        {
            var maybe = new Maybe<object>();

            Assert.Equal(false, maybe.HasValue);
            Assert.Throws<InvalidOperationException>(() => maybe.Value);
        }


        [Fact]
        public void Null_is_a_valid_value()
        {
            var maybe = new Maybe<object>(null);

            Assert.Equal(true, maybe.HasValue);
            Assert.Equal(null, maybe.Value);
        }


        [Fact]
        public void A_value_can_be_casted_to_a_mabye_implicitly()
        {
            Maybe<int> maybe = 12;

            Assert.Equal(true, maybe.HasValue);
            Assert.Equal(12, maybe.Value);
        }


        [Fact]
        public void A_maybe_can_be_casted_to_a_value_explicitly()
        {
            var maybe = new Maybe<int>(12);
            int value = (int)maybe;

            Assert.Equal(12, value);
        }


        [Fact]
        public void Two_maybes_with_the_same_value_are_equal()
        {
            var one = new Maybe<int>(42);
            var two = new Maybe<int>(42);

            Assert.True(one.Equals(two));
        }


        [Fact]
        public void Two_maybes_with_different_values_are_not_equal()
        {
            var one = new Maybe<int>(42);
            var two = new Maybe<int>(9000);

            Assert.False(one.Equals(two));
        }


        [Fact]
        public void Two_maybes_with_no_value_are_equal()
        {
            var one = new Maybe<int>();
            var two = new Maybe<int>();

            Assert.True(one.Equals(two));
        }


        [Fact]
        public void Two_maybes_of_different_types_with_no_value_are_not_equal()
        {
            var one = new Maybe<int>();
            var two = new Maybe<object>();

            Assert.False(one.Equals(two));
        }


        [Fact]
        public void Two_maybes_with_the_same_value_are_equal_by_operator()
        {
            var one = new Maybe<int>(42);
            var two = new Maybe<int>(42);

            Assert.True(one == two);
        }


        [Fact]
        public void Two_maybes_with_different_values_are_not_equal_by_operator()
        {
            var one = new Maybe<int>(42);
            var two = new Maybe<int>(9000);

            Assert.True(one != two);
        }


        [Fact]
        public void Two_maybes_with_no_value_are_equal_by_operator()
        {
            var one = new Maybe<int>();
            var two = new Maybe<int>();

            Assert.True(one == two);
        }


        [Fact]
        public void Two_maybes_of_different_types_with_no_value_are_not_equal_by_operator()
        {
            var one = new Maybe<int>();
            var two = new Maybe<object>();

            Assert.True(one != two);
        }


        [Fact]
        public void Match_2_calls_value_delegate_when_it_has_value()
        {
            object value = new object();
            object a = new object(), b = new object();
            var maybe = new Maybe<object>(value);

            var result = maybe.Match(v => { Assert.Equal(value, v); return a; }, () => b);
            Assert.Equal(a, result);
        }


        [Fact]
        public void Match_2_calls_no_value_delegate_when_it_has_no_value()
        {
            object a = new object(), b = new object();
            var maybe = new Maybe<object>();

            var result = maybe.Match(v => a, () => b);
            Assert.Equal(b, result);
        }


        [Fact]
        public void Match_1_calls_delegate_when_it_has_value()
        {
            var value = new object();
            var maybe = new Maybe<object>(value);
            bool called = false;

            var result = maybe.Match(v => { Assert.Equal(value, v); called = true; });

            Assert.True(called);
            Assert.Equal(maybe, result);
        }


        [Fact]
        public void Match_1_doesnt_call_delegate_when_it_has_no_value()
        {
            var maybe = new Maybe<object>();
            bool called = false;

            var result = maybe.Match(v => { called = true; });

            Assert.False(called);
            Assert.Equal(maybe, result);
        }
    }
}
