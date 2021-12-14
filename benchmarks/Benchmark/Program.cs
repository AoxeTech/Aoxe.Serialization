namespace Benchmark;

class Program
{
    static void Main(string[] args)
    {
        var assembly = typeof(TestModel).Assembly;
        var summaries = BenchmarkRunner.Run(assembly);
        foreach (var summary in summaries)
        {
            Console.WriteLine(summary.ResultsDirectoryPath);
            Console.WriteLine(string.Join("\r\n", summary.Reports));
        }
    }
}