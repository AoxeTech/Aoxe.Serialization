using Benchmark.Benchmarks;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializeBenchmark = BenchmarkRunner.Run<SerializeBenchmark>();
            var packBenchmark = BenchmarkRunner.Run<PackBenchmark>();
            var serializeTextBenchmark = BenchmarkRunner.Run<SerializeTextBenchmark>();
            
            var deserializeBenchmark = BenchmarkRunner.Run<DeserializeBenchmark>();
            var unpackBenchmark = BenchmarkRunner.Run<UnpackBenchmark>();
            var deserializeTextBenchmark = BenchmarkRunner.Run<DeserializeTextBenchmark>();
        }
    }
}