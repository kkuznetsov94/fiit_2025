using NUnit.Framework;

namespace Example;

public class ProblemExample
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
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
        public void GetIvanTest_BadExample()
        {
            var expected = new Person { Name = "Ivan", Age = 22 };

            var actual = PersonGetter.GetIvan();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}