using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.Protobuf;
using Zaabee.SystemTextJson;
using Zaabee.Utf8Json;
using Zaabee.Xml;
using Zaabee.ZeroFormatter;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class PackBenchmarkAsync
    {
        private readonly TestModel _testModel = new TestModel
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            CreateTime = new DateTime(2017, 1, 1),
            Name = "apple",
            Gender = Gender.Female
        };

        [Benchmark]
        public async Task NewtonsoftJsonPackAsync() => await NewtonsoftJsonHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task ProtobufPackAsync() => await ProtobufHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task SystemTextJsonPackAsync() => await SystemTextJsonHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task Utf8JsonPackAsync() => await Utf8JsonHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task XmlPackAsync() => await XmlHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task ZeroFormatterPackAsync() => await ZeroFormatterHelper.PackAsync(_testModel);
    }
}