using AppLogic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace BenchmarkExample
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
   // [SimpleJob(runStrategy: RunStrategy.ColdStart,  targetCount: 5)] //for faster benchmarking
    public class BenchmarkTests
    {
        private ISolution solution = new Solution();

        [Benchmark]
        public void MiddleSumBenchmarkQuickTest()
        {
            decimal[] arr = { 0, 0, 0 };
            solution.SumMiddle(arr);
        }

        [Benchmark]
        public void MiddleSumBenchmarkMiddleLongTest()
        {
            decimal[] arr = { 10, 24, 37, 50, 51, 52, 53, 55, 57, 64, 65, 91 };
            solution.SumMiddle(arr);
        }

        [Benchmark]
        public void MiddleSumBenchmarkLongTest()
        {
            decimal[] arr = { 1, 7, 10, 24, 33, 37, 42, 47, 49, 50, 51, 52,
                53, 55, 57, 64, 65, 70, 84, 87, 89, 91, 100, 121,
                215, 220, 222, 231, 233, 240, 245};
            solution.SumMiddle(arr);
        }

        [Benchmark]
        public void ZigZagSortBenchmarkQuickTest()
        {
            decimal[] arr = { 0, 3 };
            solution.ZigZagSort(arr);
        }

        [Benchmark]
        public void ZigZagSortBenchmarkLongTest()
        {
            decimal[] arr = {0,3,10,6,7,8,17,54,32,4,22,12,11,23,24,
                55,78,9,3,20,14,64,77,33,21,19,5,43,34,13,15,16,1,30,
                18,2,31,76,27,29,36,38,40,};
            solution.ZigZagSort(arr);
        }

        [Benchmark]
        public void ZigZagSortBenchmarkSortedTest()
        {
            decimal[] arr = {0,3,2,10,9,20,1,7,4,12,8,21,15,19,5,18,6,17,11,16,14};
            solution.ZigZagSort(arr);
        }

        [Benchmark]
        public void ArrayGameBenchmarkQuickTest()
        {
            decimal[] arr = { 0,1,2,2,};
            solution.ArrayGame(arr);
        }

        [Benchmark]
        public void ArrayGameBenchmarkMiddleLongTest()
        {
            decimal[] arr = { 3, 2, 20, 1, 2, 4, 16, 12, 8, 7 };
            solution.ArrayGame(arr);
        }

        [Benchmark]
        public void ArrayGameBenchmarkLongTest()
        {
            decimal[] arr = {11, 10, 3, 2, 20, 1, 2, 4, 16, 12, 8, 7, 14, 15, 4, 9, 1, 6,  };
            solution.ArrayGame(arr);
        }
    }
}
