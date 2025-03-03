using System.Globalization;
using NUnit.Framework;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Example;

public class WithJsonSerializer
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
        public void GetIvanTest_WithJsonSerialization()
        {
            var expectedPerson = new Person { Name = "Ivan", Age = 23};
            var actualPerson = PersonGetter.GetIvan();


            Assert.That(JsonSerializer.Serialize(actualPerson), 
                Is.EqualTo(JsonSerializer.Serialize(expectedPerson)), message:$"expected {JsonSerializer.Serialize(actualPerson)} but found" );
        }
    }
}