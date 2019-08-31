using System;
using BenchmarkDotNet.Attributes;
using Zaabee.Binary;
using Zaabee.Jil;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.Protobuf;
using Zaabee.Utf8Json;
using Zaabee.Xml;
using Zaabee.ZeroFormatter;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class SerializeBenchmark
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
        public void BinarySerialize() => BinaryHelper.Serialize(_testModel);

        [Benchmark]
        public void JilSerialize() => JilHelper.Serialize(_testModel);

        [Benchmark]
        public void MsgPackSerialize() => MsgPackHelper.Serialize(_testModel);

        [Benchmark]
        public void NewtonsoftJsonSerialize() => NewtonsoftJsonHelper.Serialize(_testModel);

        [Benchmark]
        public void ProtobufSerialize() => ProtobufHelper.Serialize(_testModel);

        [Benchmark]
        public void Utf8JsonSerialize() => Utf8JsonHelper.Serialize(_testModel);

        [Benchmark]
        public void XmlSerialize() => XmlHelper.Serialize(_testModel);

        [Benchmark]
        public void ZeroFormatterSerialize() => ZeroFormatterHelper.Serialize(_testModel);
    }
}