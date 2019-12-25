using System;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = typeof(TestModel).Assembly;
            var summaries = BenchmarkRunner.Run(assembly);
            foreach (var summary in summaries)
            {
                Console.WriteLine(summary.ResultsDirectoryPath);
                foreach (var benchmarkReport in summary.Reports)
                    Console.WriteLine(benchmarkReport);
            }
        }
    }
}