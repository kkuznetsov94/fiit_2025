using NUnit.Framework;

namespace e2_TestFixtures._2_OneTimeSetupAndTearDownExamples;

public class OneTimeSetupExamples : BaseClass
{
    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        TestContext.Out.WriteLine("OneTimeSetUp");
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
        TestContext.Out.WriteLine("OneTimeTearDown");
    }

    //Выполняется перед каждым тестом внутри класса
    [SetUp]
    public static void SetUp()
    {
        TestContext.Out.WriteLine("SetUp");
    }

    //Выполняется после каждого теста внутри класса
    [TearDown]
    public static void TearDown()
    {
        TestContext.Out.WriteLine("TearDown");
    }


    [Test]
    public void SuccessTest()
    {
        Assert.That(true);
    }

    [Test]
    public void FailedTest()
    {
        Assert.That(false);
    }
}