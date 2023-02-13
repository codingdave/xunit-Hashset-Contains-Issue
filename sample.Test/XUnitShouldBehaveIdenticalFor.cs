using Xunit;
namespace sample.Test
{
    public class XUnitShouldBehaveIdenticalToSdkFor
    {
        private HashSet<BrokenGetHashCode> _collection;
        private BrokenGetHashCode _item;

        public XUnitShouldBehaveIdenticalToSdkFor()
        {
            _collection = new HashSet<BrokenGetHashCode> { new BrokenGetHashCode("a") };
            _item = _collection.First();
        }

        [Fact]
        public void AssertContainsIDictionary()
        {
            var collection = new Dictionary<BrokenGetHashCode, string>
            {
                { new BrokenGetHashCode("a"), "a" }
            };
            var item = collection.First();
            Assert.Contains(item, collection);
#pragma warning disable xUnit2017 // Do not use Contains() to check if a value exists in a collection
            Assert.True(collection.Contains(item));
#pragma warning restore xUnit2017 // Do not use Contains() to check if a value exists in a collection
            // Since GetHashCode uses the mutable property this line will make Contains calls fail
            item.Key.MutableProperty = "b";
            Assert.DoesNotContain(item, collection);
#pragma warning disable xUnit2017 // Do not use Contains() to check if a value exists in a collection
            Assert.False(collection.Contains(item));
#pragma warning restore xUnit2017 // Do not use Contains() to check if a value exists in a collection
        }

        [Fact]
        public void AssertContainsISet()
        {
            var collection = new HashSet<BrokenGetHashCode> { new BrokenGetHashCode("a") };
            var item = collection.First();
            Assert.NotNull(item);
            Assert.Contains(item, collection);
#pragma warning disable xUnit2017 // Do not use Contains() to check if a value exists in a collection
            Assert.True(collection.Contains(item));
#pragma warning restore xUnit2017 // Do not use Contains() to check if a value exists in a collection
            // Since GetHashCode uses the mutable property this line will make Contains calls fail
            item.MutableProperty = "b";
            Assert.DoesNotContain(item, collection);
#pragma warning disable xUnit2017 // Do not use Contains() to check if a value exists in a collection
            Assert.False(collection.Contains(item));
#pragma warning restore xUnit2017 // Do not use Contains() to check if a value exists in a collection
        }

        [Fact]
        public void xUnitAssertContains()
        {
            Assert.NotNull(_item);
            Assert.Contains(_item, _collection);
            _item.MutableProperty = "b";
            Assert.Contains(_item, _collection);
        }
    }
}