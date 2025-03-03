using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace Example._1._BaseExamples;

public partial class BaseAssertExamples
{
    //Классический подход Nunit
    [Test]
    public void Add_ShouldReturn_CorrectSum_PositiveNumbers_()
    {
        var a = 1;
        var b = 2;
        var expected = 6;
        var calculator = new Calculator();

        var result = calculator.Add(a, b);

        //Классический подход Nunit
        Assert.AreEqual(result, expected);
        Assert.That(result, Is.EqualTo(expected));

        result.Should().Equals(expected);
    }

    [Test]
    public void IsEmptyTest()
    {
        var emptyList = new List<string> { };

        //Классический подход Nunit
        Assert.IsEmpty(emptyList);

        //Constraint подход
        Assert.That(emptyList, Is.Empty);

        //fluentAssetions
        emptyList.Should().BeEmpty();
    }

    [Test]
    public void Check_WhenEqual_ReturnTrue()
    {
        var a = 2;
        var condition = a == 3;

        //Классический подход Nunit
        Assert.IsTrue(condition, $"Ожидали, что {a} = 3");

        //Constraint подход
        Assert.That(condition, Is.True);

        //fluentAssetions
        condition.Should().BeTrue();
    }

    [Test]
    public void WithThrowTest()
    {
        var calculator = new Calculator();

        //Классический подход Nunit
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(1, 0));

        //Constraint подход
        Assert.That(() => calculator.Divide(1, 0), Throws.TypeOf<DivideByZeroException>());

        //fluentAssertions
        var action = () => calculator.Divide(1, 0);
        action.Should().Throw<DivideByZeroException>();
    }


    [Test]
    public void WithCustomMessageTest()
    {
        var a = 1;
        var b = 2;
        var expected = 6;
        var calculator = new Calculator();

        var result = calculator.Add(a, b);
        
        result.Should().Be(expected, $"сумма {a} и {b} должна быть равна {expected}");
    }


    [Test]
    public void WithMultiplyTest()
    {
        var a = 1;
        var b = 2;
        var expected = 4;
        var calculator = new Calculator();

        var result = calculator.Add(a, b);

        Assert.Multiple(() =>
        {
            Assert.AreEqual(result, expected, message: $"Ожидали, что сумма {a} и {b} будет равна {expected}," +
                                                       $" но получили {result}");
            Assert.That(result, Is.EqualTo(expected), message: $"Ожидали, что сумма {a} и {b} будет равна {expected}," +
                                                               $" но получили {result}");
        });

        using (new AssertionScope())
        {
            result.Should().Be(expected, $"сумма {a} и {b} должна быть равна {expected}");
        }
    }

    [Test]
    public void WithAfter()
    {
        var calculator = new Calculator();

        calculator.TurnOff();
        // поправить пример
        Assert.That(calculator.IsOff, Is.True.After(20000, 1000));
    }
}

public class Calculator
{
    private bool isOff;

    public bool IsOff => isOff;

    public float Add(float a, float b)
    {
        return a + b;
    }

    public float Subtract(float a, float b)
    {
        return a - b;
    }

    public float Multiply(float a, float b)
    {
        return a * b;
    }

    public float Divide(float a, float b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return a / b;
    }

    public async Task TurnOff()
    {
        await Task.Delay(5000); // Задержка в 5 секунд
        isOff = true; // Переключение флага после задержки
    }
}