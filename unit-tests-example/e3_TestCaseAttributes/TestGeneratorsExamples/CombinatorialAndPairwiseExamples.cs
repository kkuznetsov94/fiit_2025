using NUnit.Framework;

namespace BaseExamples.TestGeneratorsExamples;

public class CombinatorialExamples
{
    
    //https://docs.nunit.org/articles/nunit/writing-tests/attributes/combinatorial.html
    [Test, Combinatorial]
    public void CombinatorialTest(
        [Values(1, 2, 3, 4, 5 )] int x,
        [Values("A", "B", "C", "D", "E")] string s)
    {
        //some test
    }
    
    //https://docs.nunit.org/articles/nunit/writing-tests/attributes/pairwise.html
    [Test, Pairwise]
    public void PairwiseTest(
        [Values("a", "b", "c", "d")] string a,
        [Values("+", "-", "?")] string b,
        [Values("x", "y", "z")] string c)
    {
       
    }

}