using NUnit.Framework;

namespace e2_TestFixtures._1_SetUpTearDownExamples;

public class SetUpTearDownExamples
{
    [SetUp]
    public static void DoSomethingBeforeTest()
    {
        TestContext.Out.WriteLine("something before test");
    }

    [TearDown]
    public static void DoSomethingAfterTest()
    {
        TestContext.Out.WriteLine("something after test");
    }
    

    [Test]
    public void MyTest()
    {
        TestContext.Out.WriteLine("         Прогон успешного теста");
    }

    [Test]
    public void MyTest2()
    {
        
        TestContext.Out.WriteLine("         Прогон упавшего теста");
        Assert.That(false);
    }


}