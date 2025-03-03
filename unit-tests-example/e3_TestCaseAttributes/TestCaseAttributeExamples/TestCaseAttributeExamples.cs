using NUnit.Framework;

namespace BaseExamples.TestCaseAttributeExamples;

public class TestCaseAttributeExamples
{
    // With expected Result as parameter
    [TestCase(1, 2, 5, TestName = "2 positive numbers")]
    [TestCase(-1, 3, 2, TestName = "negative and positive numbers")]
    public void Add_TwoNumbers_ReturnCorrectSum(int a, int b, int expected)
    {
        var calculator = new Calculator();

        Assert.That(calculator.Add(a, b), Is.EqualTo(expected));
    }


    // With expected Result as attribute 
    [TestCase(2, 2, ExpectedResult = 4)]
    [TestCase(0, 1, ExpectedResult = 1)]
    [TestCase(1, -1, ExpectedResult = 2)]
    public float TestsWithExpectedResult(int a, int b)
    {
        var calculator = new Calculator();
        return calculator.Add(a, b);
    }

    // With Name
    [TestCase(2, 2, 4, TestName = "PositiveWithPositive")]
    [TestCase(0, 1, 4, TestName = "PositiveWithZero")]
    [TestCase(1, -1, 0, TestName = "PositiveWithNegative")]
    public void TestsWithNames(int a, int b, int c)
    {
        var calculator = new Calculator();

        Assert.That(calculator.Add(a, b), Is.EqualTo(c));
    }


    // With ignore 
    [TestCase(12, 3, ExpectedResult = 4, Ignore = "BadTest")]
    [TestCase(1, 1, ExpectedResult = 2)]
    public float TestsWithIgnoredCase(int a, int b)
    {
        var calculator = new Calculator();

        return calculator.Add(a, b);
    }
}