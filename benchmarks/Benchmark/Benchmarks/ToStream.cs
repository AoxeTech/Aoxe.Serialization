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
    public class ToStream
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
        public void BinaryToStream() => BinaryHelper.Pack(_testModel);

        [Benchmark]
        public void JilToStream() => JilHelper.Pack(_testModel);

        [Benchmark]
        public void MsgPackToStream() => MsgPackHelper.Pack(_testModel);

        [Benchmark]
        public void NewtonsoftJsonToStream() => NewtonsoftJsonHelper.Pack(_testModel);

        [Benchmark]
        public void ProtobufToStream() => ProtobufHelper.Pack(_testModel);

        [Benchmark]
        public void SystemTextJsonToStream() => SystemTextJsonHelper.Pack(_testModel);

        [Benchmark]
        public void Utf8JsonToStream() => Utf8JsonHelper.Pack(_testModel);

        [Benchmark]
        public void XmlToStream() => XmlHelper.Pack(_testModel);

        [Benchmark]
        public void ZeroFormatterToStream() => ZeroFormatterHelper.Pack(_testModel);
    }
}