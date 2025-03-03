using NUnit.Framework;

namespace BaseExamples.TestAttributeExamples;


public class TestAttributeExamples
{
    // Базовый пример использования аттрибута. 
    [Test]
    public void Sum_should_returnTrue()
    {
        Assert.That(false);
    }

    // Добавление описания к тесту
    [Test(Description = "123123") ]
    public void TestWithDescription()
    {
        Assert.That(true);
    }

    // Передача ожидаемого результата в параметрах теста
    [Test(ExpectedResult = 4)]
    public float TestWithExpectedResult()
    {
        var calculator = new Calculator();
        
        return calculator.Add(3, 2);
    }
    [Test(ExpectedResult = 5)]
    public float TestWithExpectedResult2()
    {
        var calculator = new Calculator();
        
        return calculator.Add(3, 2);
    }

    [Test(TestOf = typeof(Calculator))]
    public void TestWithTypeOf()
    {
        Assert.That(true);
    }

    // Может применяться к асинхронным тестовым методам
    [Test]
    public async Task AsyncTest()
    {
        Assert.That(true);
    }
    
}