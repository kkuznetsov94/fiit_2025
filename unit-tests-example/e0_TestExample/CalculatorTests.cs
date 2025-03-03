using NUnit.Framework;

namespace e1_TestExample;

public  class CalculatorTests
{
   [Test]
    public static void CalculatorAddTest( int a, int b, int c)
    {
        var calculator = new Calculator();
        
        var actual = calculator.Add(1, 2);
        
        Assert.That(actual, Is.EqualTo(3));
    }

    public class TestFailedException : Exception
    {
        public TestFailedException()
        {
        }
    }
    
    
    
}