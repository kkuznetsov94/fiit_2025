using NUnit.Framework;

namespace e2_TestFixtures._2_OneTimeSetupAndTearDownExamples;

public class OneTimeSetupExamples2 : BaseClass
{
    [OneTimeSetUp]
    public static void OneTimeSetUp2()
    {
        TestContext.Out.WriteLine("OneTimeSetUp2");
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown2()
    {
        TestContext.Out.WriteLine("OneTimeTearDown2");
    }

    [SetUp]
    public static void SetUp2()
    {
        TestContext.Out.WriteLine("         SetUp2");
    }

    [TearDown]
    public static void TearDown2()
    {
        TestContext.Out.WriteLine("         TearDown2");
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