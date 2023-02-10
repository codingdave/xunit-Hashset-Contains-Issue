namespace sample.Test
{
    public class ClassWithBrokenGetHashCode
    {
        public ClassWithBrokenGetHashCode(string s) => MutableProperty = s;

        public string MutableProperty { get; set; }

        // You should never implement GetHashCode using mutable data.
        public override int GetHashCode() => MutableProperty.GetHashCode();
    }
}