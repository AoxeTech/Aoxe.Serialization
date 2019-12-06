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
    public class DeserializeBenchmark
    {
        private readonly TestModel _testModel = new TestModel
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            CreateTime = new DateTime(2017, 1, 1),
            Name = "apple",
            Gender = Gender.Female
        };

        private readonly byte[] _binaryBytes;
        private readonly byte[] _jilBytes;
        private readonly byte[] _msgPackBytes;
        private readonly byte[] _newtonsoftJsonBytes;
        private readonly byte[] _protobufBytes;
        private readonly byte[] _systemTextJsonBytes;
        private readonly byte[] _utf8JsonBytes;
        private readonly byte[] _xmlBytes;
        private readonly byte[] _zeroFormatterBytes;

        public DeserializeBenchmark()
        {
            _binaryBytes = BinaryHelper.Serialize(_testModel);
            _jilBytes = JilHelper.Serialize(_testModel);
            _msgPackBytes = MsgPackHelper.Serialize(_testModel);
            _newtonsoftJsonBytes = NewtonsoftJsonHelper.Serialize(_testModel);
            _protobufBytes = ProtobufHelper.Serialize(_testModel);
            _systemTextJsonBytes = SystemTextJsonHelper.Serialize(_testModel);
            _utf8JsonBytes = Utf8JsonHelper.Serialize(_testModel);
            _xmlBytes = XmlHelper.Serialize(_testModel);
            _zeroFormatterBytes = ZeroFormatterHelper.Serialize(_testModel);
        }

        [Benchmark]
        public void BinaryDeserialize() => BinaryHelper.Deserialize<TestModel>(_binaryBytes);

        [Benchmark]
        public void JilDeserialize() => JilHelper.Deserialize<TestModel>(_jilBytes);

        [Benchmark]
        public void MsgPackDeserialize() => MsgPackHelper.Deserialize<TestModel>(_msgPackBytes);

        [Benchmark]
        public void NewtonsoftJsonDeserialize() => NewtonsoftJsonHelper.Deserialize<TestModel>(_newtonsoftJsonBytes);

        [Benchmark]
        public void ProtobufDeserialize() => ProtobufHelper.Deserialize<TestModel>(_protobufBytes);

        [Benchmark]
        public void SystemTextJsonDeserialize() => SystemTextJsonHelper.Deserialize<TestModel>(_systemTextJsonBytes);

        [Benchmark]
        public void Utf8JsonSerializeDeserialize() => Utf8JsonHelper.Deserialize<TestModel>(_utf8JsonBytes);

        [Benchmark]
        public void XmlDeserialize() => XmlHelper.Deserialize<TestModel>(_xmlBytes);

        [Benchmark]
        public void ZeroFormatterDeserialize() => ZeroFormatterHelper.Deserialize<TestModel>(_zeroFormatterBytes);
    }
}