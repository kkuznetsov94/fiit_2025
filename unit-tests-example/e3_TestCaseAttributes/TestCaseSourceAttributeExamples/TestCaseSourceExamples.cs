using BaseExamples.TestCaseSourceAttributeExamples.RectangleCalculation;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace BaseExamples.TestCaseSourceAttributeExamples;

public class TestCaseSourceExamples
{
    #region attributeArgumetsExample

    [TestCaseSource(nameof(RectangleCasesWithTestCaseData))]
    [TestCaseSource(nameof(RectangleCases))]
    public void RectangleCalculatorTest(Rectangle a, Rectangle b, int expected)
    {
        var result = RectangleCalculator.GetIntersectionSquare(a, b);
        Assert.That(result == expected);
    }

    #endregion

    // статический массив объектов содержащий данные для тест кейсов
    public static object[] RectangleCases =
    {
        new object[] { new Rectangle(0, 1, 2, 2), new Rectangle(0, 0, 1, 1), 0 },
        new object[] { new Rectangle(0, 0, 1, 1), new Rectangle(2, 2, 3, 3), 0 },
        new object[] { new Rectangle(0, 0, 2, 2), new Rectangle(1, 1, 3, 3), 1 },
    };

    public static TestCaseData[] RectangleCasesWithTestCaseData =
    {
        new TestCaseData(new Rectangle(0, 1, 2, 2), new Rectangle(0, 0, 1, 1), 0)
            .SetName("Return Zero if intersected only by border"),
        new TestCaseData(new Rectangle(0, 0, 1, 1), new Rectangle(1, 1, 3, 3), 0)
            .SetName("Return Zero if intersected by only one point"),
        new TestCaseData(new Rectangle(0, 0, 2, 2), new Rectangle(1, 1, 3, 3), 1)
            .SetName("Return value if intersected"),
    };


    // статический метод возвращающий данные для тест кейсов
    public static IEnumerable<TestCaseData> RectangleCasesMethod()
    {
        yield return new TestCaseData(new Rectangle(0, 1, 2, 2), new Rectangle(0, 0, 1, 1), 0)
            .SetName("Return Zero if intersected only by border");
        yield return new TestCaseData(new Rectangle(0, 0, 1, 1), new Rectangle(1, 1, 3, 3), 0)
            .SetName("Return Zero if intersected by only one point");
        yield return new TestCaseData(new Rectangle(0, 0, 2, 2), new Rectangle(1, 1, 3, 3), 1)
            .SetName("Return value if intersected");
    }


    [TestCaseSource(nameof(RectangleCases))]
    public void RectangleCalculatorTestWithSource(Rectangle a, Rectangle b, int expected)
    {
        var result = RectangleCalculator.GetIntersectionSquare(a, b);
        Assert.AreEqual(expected, result);
    }


    public enum Colour
    {
        Undefined,
        Red,
        Blue,
        Black,
        White,
        Purple,
        Green
    }

    private static readonly IEnumerable<TestCaseData> DefinedColoursCases =
        Enum.GetValues<Colour>()
            .Except(new[] { Colour.Undefined })
            .Select(c => new TestCaseData()
                .SetName($"Colour {c}"));

    [TestCaseSource(nameof(DefinedColoursCases))]
    public void Paint_SetPassedColour_IfColourIsDefined(Colour colour)
    {
        ///Тут какая-то магия
    }

    [TestCaseSource(nameof(DefinedColoursCases))]
    public void ThrowExceptionIfColourIsUndefined()
    {
        ///Тут какая-то магия
    }
}