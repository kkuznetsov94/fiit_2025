using NUnit.Framework;

namespace e2_TestFixtures._3_SetUpFixtureExamples.Example2;

public class BaseClass2
{
    [OneTimeSetUp]
    public static void BaseOneTimeSetUp()
    {
        TestContext.Out.WriteLine("BaseOneTimeSetUp");
    }

    [OneTimeTearDown]
    public static void BaseOneTimeTearDown()
    {
        TestContext.Out.WriteLine("BaseOneTimeTearDown");
    }

    [SetUp]
    public static void BaseSetUp()
    {
        TestContext.Out.WriteLine("BaseSetUp");
    }

    [TearDown]
    public static void BaseTearDown()
    {
        TestContext.Out.WriteLine("BaseTearDown");
    }
}