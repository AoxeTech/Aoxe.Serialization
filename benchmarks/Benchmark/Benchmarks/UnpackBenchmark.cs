using System;
using System.IO;
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

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class UnpackBenchmark
    {
        private readonly TestModel _testModel = new TestModel
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            CreateTime = new DateTime(2017, 1, 1),
            Name = "apple",
            Gender = Gender.Female
        };

        private readonly Stream _binaryStream;
        private readonly Stream _jilStream;
        private readonly Stream _msgPackStream;
        private readonly Stream _newtonsoftJsonStream;
        private readonly Stream _protobufStream;
        private readonly Stream _systemTextJsonStream;
        private readonly Stream _utf8JsonStream;
        private readonly Stream _xmlStream;

        public UnpackBenchmark()
        {
            _binaryStream = BinaryHelper.Pack(_testModel);
            _jilStream = JilHelper.Pack(_testModel);
            _msgPackStream = MsgPackHelper.Pack(_testModel);
            _newtonsoftJsonStream = NewtonsoftJsonHelper.Pack(_testModel);
            _protobufStream = ProtobufHelper.Pack(_testModel);
            _systemTextJsonStream = SystemTextJsonHelper.Pack(_testModel);
            _utf8JsonStream = Utf8JsonHelper.Pack(_testModel);
            _xmlStream = XmlHelper.Pack(_testModel);
        }

        [Benchmark]
        public void BinaryUnpack() => BinaryHelper.Unpack<TestModel>(_binaryStream);

        [Benchmark]
        public void JilUnpack() => JilHelper.Unpack<TestModel>(_jilStream);

        [Benchmark]
        public void MsgPackUnpack() => MsgPackHelper.Unpack<TestModel>(_msgPackStream);

        [Benchmark]
        public void NewtonsoftJsonUnpack() => NewtonsoftJsonHelper.Unpack<TestModel>(_newtonsoftJsonStream);

        [Benchmark]
        public void ProtobufUnpack() => ProtobufHelper.Unpack<TestModel>(_protobufStream);

        [Benchmark]
        public void SystemTextJsonUnpack() => SystemTextJsonHelper.Unpack<TestModel>(_systemTextJsonStream);

        [Benchmark]
        public void Utf8JsonUnpack() => Utf8JsonHelper.Unpack<TestModel>(_utf8JsonStream);

        [Benchmark]
        public void XmlUnpack() => XmlHelper.Unpack<TestModel>(_xmlStream);
    }
}