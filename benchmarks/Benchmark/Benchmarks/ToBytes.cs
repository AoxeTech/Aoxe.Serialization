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
    public class ToBytes
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
        public void BinaryToBytes() => BinaryHelper.ToBytes(_testModel);

        [Benchmark]
        public void JilToBytes() => JilHelper.ToBytes(_testModel);

        [Benchmark]
        public void MessagePackToBytes() => MessagePackHelper.ToBytes(_testModel);

        [Benchmark]
        public void MsgPackToBytes() => MsgPackHelper.ToBytes(_testModel);

        [Benchmark]
        public void NewtonsoftJsonToBytes() => NewtonsoftJsonHelper.ToBytes(_testModel);

        [Benchmark]
        public void ProtobufToBytes() => ProtobufHelper.ToBytes(_testModel);

        [Benchmark]
        public void SystemTextJsonToBytes() => SystemTextJsonHelper.ToBytes(_testModel);

        [Benchmark]
        public void Utf8JsonToBytes() => Utf8JsonHelper.ToBytes(_testModel);

        [Benchmark]
        public void XmlToBytes() => XmlHelper.ToBytes(_testModel);

        [Benchmark]
        public void ZeroFormatterToBytes() => ZeroFormatterHelper.ToBytes(_testModel);
    }
}