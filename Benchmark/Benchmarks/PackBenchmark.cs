using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Binary;
using Zaabee.Jil;
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
    public class PackBenchmark
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
        public void BinaryPack() => BinaryHelper.Pack(_testModel);

        [Benchmark]
        public void JilPack() => JilHelper.Pack(_testModel);

        [Benchmark]
        public void MsgPackPack() => MsgPackHelper.Pack(_testModel);

        [Benchmark]
        public void NewtonsoftJsonPack() => NewtonsoftJsonHelper.Pack(_testModel);

        [Benchmark]
        public void ProtobufPack() => ProtobufHelper.Pack(_testModel);

        [Benchmark]
        public void SystemTextJsonPack() => SystemTextJsonHelper.Pack(_testModel);

        [Benchmark]
        public void Utf8JsonPack() => Utf8JsonHelper.Pack(_testModel);

        [Benchmark]
        public void XmlPack() => XmlHelper.Pack(_testModel);

        [Benchmark]
        public void ZeroFormatterPack() => ZeroFormatterHelper.Pack(_testModel);
    }
}