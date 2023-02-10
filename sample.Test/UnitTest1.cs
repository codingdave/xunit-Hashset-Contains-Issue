using Xunit;
namespace sample.Test
{
    public class Person
    {
        public Person(string name) => Name = name;

        public string Name { get; set; }

        public override int GetHashCode() => Name.GetHashCode();
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var persons = new HashSet<Person> { new Person("a") };
            var firstPerson = persons.First();
            Assert.NotNull(firstPerson);
            Assert.Contains(firstPerson, persons);
            Assert.True(persons.Contains(firstPerson));
            firstPerson.Name = "b";
            Assert.Contains(firstPerson, persons);
            Assert.True(persons.Contains(firstPerson));
        }
    }
}