# Stugo.Maybe

Adds support for a `Maybe` type. The `null` value does not necessarily imply "no value", since it
is itself a value.  The `Maybe` type explicitly represents the presence/absence of a value.

A `Maybe` has a type, a flag to say whether or not it has a value, and sometimes a value:

```csharp
struct Maybe<T>
{
    bool HasValue { get; }
    T Value { get; }
}

The `Maybe` is immutable.  Attempting to fetch the value when the instance has no value will 
result in a `InvalidOperationException`.


## Casting

For convenience, it is possible to cast between a `Maybe` and its type:

```csharp
Maybe<int> maybe = 23;  // this cast can be done implicitly
int value = (int)maybe; // because of the chance of an exception, this cast must be explicit
```


## Equality

For convenience, `GetHashCode`, `Equals` and the operators `==` and `!=` have all been defined as
expected.


## Matching 

To coalesce a maybe which possibly doesn't have a value into its underlying type, use match:

```csharp
Maybe<int> maybe = new Maybe<int>();        // no value 
int value = maybe.Match(v => v, () => 42);  // return the value if set, or 42 
```

To execute something only if the maybe has a value, use the single-argument form of `Match`:

```csharp
Maybe<int> maybe = 12;
maybe.Match(() => { /* do something */ });
```

This method returns the `Maybe` instance to allow chaining.


## Enumerables

This library also provides extension methods for `IEnumerable<>`:

```csharp
Maybe<T> FirstOrNothing<T>(this IEnumerable<T> src);
Maybe<T> FirstOrNothing<T>(this IEnumerable<T> src, Func<T, bool> predicate);
Maybe<T> SingleOrNothing<T>(this IEnumerable<T> src);
Maybe<T> SingleOrNothing<T>(this IEnumerable<T> src, Func<T, bool> predicate);
```

These are similar to their `FirstOrDefault` and `SingleOrDefault` counterparts, except they return
an `Maybe` with no value if the list is empty.