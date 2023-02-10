using Xunit;
namespace sample.Test
{
    public class XUnitShouldBehaveIdenticalFor
    {
        private HashSet<ClassWithBrokenGetHashCode> _collection;
        private ClassWithBrokenGetHashCode _item;

        public XUnitShouldBehaveIdenticalFor()
        {
            _collection = new HashSet<ClassWithBrokenGetHashCode> { new ClassWithBrokenGetHashCode("a") };
            _item = _collection.First();
        }

        [Fact]
        public void xUnitAssertContains()
        {
            Assert.NotNull(_item);
            Assert.Contains(_item, _collection);
            _item.MutableProperty = "b";
            Assert.Contains(_item, _collection);
        }

        [Fact]
        public void HashSetContains()
        {
#pragma warning disable xUnit2017 // Do not use Contains() to check if a value exists in a collection
            Assert.NotNull(_item);
            Assert.True(_collection.Contains(_item));
            _item.MutableProperty = "b";
            // This will fail, because the Name property has been modified GetHashCode is working on.
            // Although this is a bug in the implementation of GetHashCode I as a user of xUnit expect identical behavior for identically named functionality.
            // Even further the analyzer warning xUnit2017 suggests that using xUnit.Assert.Contains is preferable and so implicitly says the behavior is equivalent, which it is not.
            Assert.True(_collection.Contains(_item)); 
#pragma warning restore xUnit2017 // Do not use Contains() to check if a value exists in a collection
        }
    }
}