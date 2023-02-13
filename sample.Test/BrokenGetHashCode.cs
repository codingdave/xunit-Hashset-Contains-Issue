namespace sample.Test
{
    public class BrokenGetHashCode
    {
        public BrokenGetHashCode(string s) => MutableProperty = s;

        public string MutableProperty { get; set; }

        // You should never implement GetHashCode using mutable data.
        public override int GetHashCode() => MutableProperty.GetHashCode();
    }
}