using AppLogic;
using Xunit.Abstractions;

namespace SolutionTests;

public class UnitTest
{

    private readonly ITestOutputHelper testConsole;

    public UnitTest(ITestOutputHelper output)
    {
        this.testConsole = output;
    }

    [Theory]
    [InlineData(32, new int[] { 9, 10, 12, 10, 9, 11 })]
    [InlineData(3, new int[] { 0, 1, 1, 2 })]
    [InlineData(18, new int[] { 8, 9, 3, 9 })]
    [InlineData(16, new int[] { 5, 12, 1, 4 })]
    [InlineData(26, new int[] { 2, 12, 8, 4, 16, 5 })]
    [InlineData(18, new int[] { 0, 1, 2, 0, 16, 12 })]
    [InlineData(49, new int[] { 3, 2, 20, 1, 2, 4, 16, 12, 8, 7 })]
    public void ArrayGameTest(decimal expected, int[] array)
    {
        //Arrange:
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        ISolution solver = new Solution();

        //Act:
        var result = solver.ArrayGame(array.Select(a => (decimal)a).ToArray());

        var output = stringWriter.ToString();
        testConsole.WriteLine(output);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, new int[] {0,0,0,0,0,0,0})]
    [InlineData(0, new int[] { 3 })]
    [InlineData(5, new int[] { 2, 8, 9, 11, 15, 16, 18, 27 })]
    [InlineData(3, new int[] { -3, 28, 33, 40, 58 })]
    [InlineData(-1, new int[] { 2, 8, 19, 20, 27, 31, 40, 98 })]
    [InlineData(-1, new int[] { 1, 2 })]
    public void SumMiddleTest(int expected, int[] array)
    {
        //Arrange:
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        ISolution solver = new Solution();

        //Act:
        var result = solver.SumMiddle(array.Select(a => (decimal)a).ToArray());

        var output = stringWriter.ToString();
        testConsole.WriteLine(output);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 0, 1 })]
    [InlineData(new int[] { 0, 1, 2 })]
    [InlineData(new int[] { 0, 4, 1, 5 })]
    [InlineData(new int[] { 15, 23, 44, 65, 0, 2, 8, 4, 19, 13, 10, 11, 1 })]
    public void ZigZagSortTest(int[] array)
    {
        //Arrange:
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        ISolution solver = new Solution();

        //Act:
        var result = solver.ZigZagSort(array.Select(a => (decimal)a).ToArray());

        var output = stringWriter.ToString();
        testConsole.WriteLine(output);
        Assert.Equal(array.Length, result.Length);
        ZigZagCheck(result);
    }

    private void ZigZagCheck(decimal[] sortedArray)
    {
        if (sortedArray.Length < 3)
            return;

        for(int i = 2; i < sortedArray.Length; i++)
        {
            if (sortedArray[i - 2] > sortedArray[i - 1])
                Assert.True(sortedArray[i - 1] < sortedArray[i], $"Error at index {i}, expected element to be > {sortedArray[i-1]} but found {sortedArray[i]}");
            else
                Assert.True(sortedArray[i - 1] > sortedArray[i], $"Error at index {i}, expected element to be < {sortedArray[i - 1]} but found {sortedArray[i]}");

        }
    }
}
