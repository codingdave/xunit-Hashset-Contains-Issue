# xunit-HashSet-Contains-Issue
Minimal sample to show unexpected behavior of xUnit Assert.Contains

The analyzer rule [xUnit2017](https://xunit.net/xunit.analyzers/rules/xUnit2017) suggests "Do not use Assert.True() to check if a value exists in a collection. Use Assert.Contains instead."

But the behavior of both is different.

For sake of simplicity please ignore that GetHashCode works on mutable data.
