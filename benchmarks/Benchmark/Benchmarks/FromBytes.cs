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
    public class FromBytes
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
        private readonly byte[] _messagePackBytes;
        private readonly byte[] _msgPackBytes;
        private readonly byte[] _newtonsoftJsonBytes;
        private readonly byte[] _protobufBytes;
        private readonly byte[] _systemTextJsonBytes;
        private readonly byte[] _utf8JsonBytes;
        private readonly byte[] _xmlBytes;
        private readonly byte[] _zeroFormatterBytes;

        public FromBytes()
        {
            _binaryBytes = BinaryHelper.Serialize(_testModel);
            _jilBytes = JilHelper.Serialize(_testModel);
            _messagePackBytes = MessagePackHelper.Serialize(_testModel);
            _msgPackBytes = MsgPackHelper.Serialize(_testModel);
            _newtonsoftJsonBytes = NewtonsoftJsonHelper.Serialize(_testModel);
            _protobufBytes = ProtobufHelper.Serialize(_testModel);
            _systemTextJsonBytes = SystemTextJsonHelper.Serialize(_testModel);
            _utf8JsonBytes = Utf8JsonHelper.Serialize(_testModel);
            _xmlBytes = XmlHelper.Serialize(_testModel);
            _zeroFormatterBytes = ZeroFormatterHelper.Serialize(_testModel);
        }

        [Benchmark]
        public void BinaryFromBytes() => BinaryHelper.Deserialize<TestModel>(_binaryBytes);

        [Benchmark]
        public void JilFromBytes() => JilHelper.Deserialize<TestModel>(_jilBytes);

        [Benchmark]
        public void MessagePackFromBytes() => MessagePackHelper.Deserialize<TestModel>(_messagePackBytes);

        [Benchmark]
        public void MsgPackFromBytes() => MsgPackHelper.Deserialize<TestModel>(_msgPackBytes);

        [Benchmark]
        public void NewtonsoftJsonFromBytes() => NewtonsoftJsonHelper.Deserialize<TestModel>(_newtonsoftJsonBytes);

        [Benchmark]
        public void ProtobufFromBytes() => ProtobufHelper.Deserialize<TestModel>(_protobufBytes);

        [Benchmark]
        public void SystemTextJsonFromBytes() => SystemTextJsonHelper.Deserialize<TestModel>(_systemTextJsonBytes);

        [Benchmark]
        public void Utf8JsonFromBytes() => Utf8JsonHelper.Deserialize<TestModel>(_utf8JsonBytes);

        [Benchmark]
        public void XmlFromBytes() => XmlHelper.Deserialize<TestModel>(_xmlBytes);

        [Benchmark]
        public void ZeroFormatterFromBytes() => ZeroFormatterHelper.Deserialize<TestModel>(_zeroFormatterBytes);
    }
}