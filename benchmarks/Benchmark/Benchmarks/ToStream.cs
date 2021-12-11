using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Binary;
using Zaabee.Jil;
using Zaabee.MessagePack;
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
        private readonly TestModel _testModel = new()
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            CreateTime = new DateTime(2017, 1, 1),
            Name = "apple",
            Gender = Gender.Female
        };

        [Benchmark]
        public void BinaryToStream() => BinaryHelper.ToStream(_testModel);

        [Benchmark]
        public void JilToStream() => JilHelper.ToStream(_testModel);

        [Benchmark]
        public void MessagePackToStream() => MessagePackHelper.ToStream(_testModel);

        [Benchmark]
        public void MsgPackToStream() => MsgPackHelper.ToStream(_testModel);

        [Benchmark]
        public void NewtonsoftJsonToStream() => NewtonsoftJsonHelper.ToStream(_testModel);

        [Benchmark]
        public void ProtobufToStream() => ProtobufHelper.ToStream(_testModel);

        [Benchmark]
        public void SystemTextJsonToStream() => SystemTextJsonHelper.ToStream(_testModel);

        [Benchmark]
        public void Utf8JsonToStream() => Utf8JsonHelper.ToStream(_testModel);

        [Benchmark]
        public void XmlToStream() => XmlHelper.ToStream(_testModel);

        [Benchmark]
        public void ZeroFormatterToStream() => ZeroFormatterHelper.ToStream(_testModel);
    }
}