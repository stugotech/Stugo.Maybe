using System;
using System.Collections.Generic;
using System.Linq;

namespace Stugo
{
    public static class MaybeExtensions
    {
        public static Maybe<T> FirstOrNothing<T>(this IEnumerable<T> src)
        {
            var enumerator = src.GetEnumerator();

            if (!enumerator.MoveNext())
                return new Maybe<T>();
            else
                return enumerator.Current;
        }


        public static Maybe<T> FirstOrNothing<T>(this IEnumerable<T> src, Func<T, bool> predicate)
        {
            return src.Where(predicate).FirstOrNothing();
        }


        public static Maybe<T> SingleOrNothing<T>(this IEnumerable<T> src)
        {
            var enumerator = src.GetEnumerator();

            if (!enumerator.MoveNext())
                return new Maybe<T>();
            else
            {
                var value = enumerator.Current;

                if (enumerator.MoveNext())
                    throw new InvalidOperationException("Sequence contains more than one element");

                return value;
            }
        }


        public static Maybe<T> SingleOrNothing<T>(this IEnumerable<T> src, Func<T, bool> predicate)
        {
            return src.Where(predicate).SingleOrNothing();
        }
    }
}
