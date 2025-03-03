using NUnit.Framework;

namespace e2_TestFixtures._3_SetUpFixtureExamples.Example1;

public class BaseClass1
{
    [OneTimeSetUp]
    public static void BaseOneTimeSetUp()
    {
        TestContext.Out.WriteLine("OneTimeSetUp из BaseClass1");
    }

    [OneTimeTearDown]
    public static void BaseOneTimeTearDown()
    {
        TestContext.Out.WriteLine("OneTimeTearDown из BaseClass1");
    }

    [SetUp]
    public static void BaseSetUp()
    {
        TestContext.Out.WriteLine("SetUp из BaseClass1");
    }

    [TearDown]
    public static void BaseTearDown()
    {
        TestContext.Out.WriteLine("TearDown из BaseClass1");
    }
}