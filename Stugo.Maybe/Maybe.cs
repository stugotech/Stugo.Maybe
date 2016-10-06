using System;

namespace Stugo
{
    public struct Maybe<T>
    {
        public static readonly Maybe<T> Nothing;


        /// <summary>
        /// Automatically cast a value to a maybe.
        /// </summary>
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }


        /// <summary>
        /// Allow explicit vasts to the value type.
        /// </summary>
        public static explicit operator T(Maybe<T> value)
        {
            return value.Value;
        }


        /// <summary>
        /// Test for equality.
        /// </summary>
        public static bool operator ==(Maybe<T> one, Maybe<T> two)
        {
            return one.Equals(two);
        }


        /// <summary>
        /// Test for inequality.
        /// </summary>
        public static bool operator !=(Maybe<T> one, Maybe<T> two)
        {
            return !one.Equals(two);
        }


        private readonly bool _HasValue;
        private readonly T _Value;


        /// <summary>
        /// Create a new value.
        /// </summary>
        public Maybe(T value)
        {
            _HasValue = true;
            _Value = value;
        }


        /// <summary>
        /// True if this instance has a value; false otherwise.
        /// </summary>
        public bool HasValue { get { return _HasValue; } }


        /// <summary>
        /// Get the value.
        /// </summary>
        public T Value
        {
            get
            {
                if (!_HasValue)
                    throw new InvalidOperationException("Maybe value has no value");
                return _Value;
            }
        }


        /// <summary>
        /// Take an action depending on the value of this instance.
        /// </summary>
        public TOut Match<TOut>(Func<T, TOut> valueIfValue, Func<TOut> valueIfNothing)
        {
            return _HasValue ? valueIfValue(_Value) : valueIfNothing();
        }


        /// <summary>
        /// Take an action depending on the value of this instance.
        /// </summary>
        public Maybe<T> Match(Action<T> actionIfValue)
        {
            if (_HasValue)
                actionIfValue(_Value);
            return this;
        }


        /// <summary>
        /// Return a string representation of this value.
        /// </summary>
        public override string ToString()
        {
            if (_HasValue)
                return _Value.ToString();
            else
                return "nothing";
        }


        /// <summary>
        /// Get a value to use as a hash for this value.
        /// </summary>
        public override int GetHashCode()
        {
            if (_HasValue)
                return 0;
            else
                return _Value.GetHashCode();
        }


        /// <summary>
        /// Test equality of this value with another.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Maybe<T>)
            {
                var maybe = (Maybe<T>)obj;
                return _HasValue == maybe._HasValue && (!_HasValue || _Value.Equals(maybe._Value));
            }
            else if (obj is T)
            {
                return _HasValue && _Value.Equals((T)obj);
            }
            else
            {
                return false;
            }
        }
    }
}