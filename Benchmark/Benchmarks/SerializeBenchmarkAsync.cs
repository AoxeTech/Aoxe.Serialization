using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Binary;
using Zaabee.Jil;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.Protobuf;
using Zaabee.SwifterJson;
using Zaabee.Utf8Json;
using Zaabee.Xml;
using Zaabee.ZeroFormatter;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class SerializeBenchmarkAsync
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
        public async Task JilSerializeAsync() => await JilHelper.SerializeAsync(_testModel);

        [Benchmark]
        public async Task MsgPackSerializeAsync() => await MsgPackHelper.SerializeAsync(_testModel);

        [Benchmark]
        public async Task NewtonsoftJsonSerializeAsync() => await NewtonsoftJsonHelper.SerializeAsync(_testModel);

        [Benchmark]
        public async Task ProtobufSerializeAsync() => await ProtobufHelper.SerializeAsync(_testModel);

        [Benchmark]
        public async Task Utf8JsonSerializeAsync() => await Utf8JsonHelper.SerializeAsync(_testModel);

        [Benchmark]
        public async Task XmlSerializeAsync() => await XmlHelper.SerializeAsync(_testModel);

        [Benchmark]
        public async Task ZeroFormatterSerializeAsync() => await ZeroFormatterHelper.SerializeAsync(_testModel);
    }
}