using NUnit.Framework;

namespace e2_TestFixtures._3_SetUpFixtureExamples.Example2;

public class Class2 : BaseClass2
{
    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        TestContext.Out.WriteLine("     OneTimeSetUp из класса с тестами");
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
        TestContext.Out.WriteLine("     OneTimeTearDown из класса с тестами");
    }

    //Выполняется перед каждым тестом внутри класса
    [SetUp]
    public static void SetUp()
    {
        TestContext.Out.WriteLine("     SetUp из класса с тестами");
    }

    //Выполняется после каждого теста внутри класса
    [TearDown]
    public static void TearDown()
    {
        TestContext.Out.WriteLine("     TearDown из класса с тестами");
    }


    [Test]
    public void SuccessTest()
    {
        TestContext.Out.WriteLine("         Прогон успешного теста");
        Assert.That(true);
    }

    [Test]
    public void FailedTest()
    {
        TestContext.Out.WriteLine("         Прогон упавшего теста");
        Assert.That(false);
    }
}