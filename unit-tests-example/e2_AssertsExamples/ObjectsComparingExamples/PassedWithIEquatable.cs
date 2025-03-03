using NUnit.Framework;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace Example;

public class PassedWithIEquatableExample
{
    public class Person  : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public bool Equals(Person? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Age == other.Age;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }

    public static class PersonGetter
    {
        public static Person GetIvan()
        {
            return new Person { Name = "Ivan", Age = 22 };
        }
    }

    public class Tests
    {
        [Test]
        public void WithIEquatable()
        {
            var expected = new Person { Name = "Ivan", Age = 23 };

            var actual = PersonGetter.GetIvan();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}