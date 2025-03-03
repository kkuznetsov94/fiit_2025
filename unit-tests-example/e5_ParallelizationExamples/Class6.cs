using NUnit.Framework;

namespace ParallelizationExamples;

public class Class6 : BaseClass2
{
    [Test]
    public void Test1()
    {
        Thread.Sleep(5000);
    }

    [Test]
    public void Test2()
    {
        Thread.Sleep(5000);
    }

    [Test]
    public void Test3()
    {
        Thread.Sleep(5000);
    }


    [TestCase(1), TestCase(2), TestCase(3)]
    public void TestWithParams(int value)
    {
        Thread.Sleep(5000);
    }
}