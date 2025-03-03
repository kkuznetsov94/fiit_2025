using NUnit.Framework;

namespace Example;

public class WithMultiplyAsserts
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
        public void GetIvanTest_WithMultiplyAsserts()
        {
            var expected = new Person { Name = "Iv4an", Age = 225 };

            var actual = PersonGetter.GetIvan();

            Assert.Multiple(() =>
            {
                Assert.That(actual.Age, Is.EqualTo(expected.Age));
                Assert.That(actual.Name, Is.EqualTo(expected.Name));
            });
        }
    }
}