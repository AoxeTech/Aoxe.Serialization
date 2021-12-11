using System;
using System.IO;
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
    public class FromStream
    {
        private readonly TestModel _testModel = new TestModel
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            CreateTime = new DateTime(2017, 1, 1),
            Name = "apple",
            Gender = Gender.Female
        };

        private readonly Stream? _binaryStream;
        private readonly Stream? _jilStream;
        private readonly Stream? _messagePackStream;
        private readonly Stream? _msgPackStream;
        private readonly Stream? _newtonsoftJsonStream;
        private readonly Stream? _protobufStream;
        private readonly Stream? _systemTextJsonStream;
        private readonly Stream? _utf8JsonStream;
        private readonly Stream? _xmlStream;
        private readonly Stream? _zeroFormatterStream;

        public FromStream()
        {
            _binaryStream = BinaryHelper.ToStream(_testModel);
            _jilStream = JilHelper.ToStream(_testModel);
            _messagePackStream = MessagePackHelper.ToStream(_testModel);
            _msgPackStream = MsgPackHelper.ToStream(_testModel);
            _newtonsoftJsonStream = NewtonsoftJsonHelper.ToStream(_testModel);
            _protobufStream = ProtobufHelper.ToStream(_testModel);
            _systemTextJsonStream = SystemTextJsonHelper.ToStream(_testModel);
            _utf8JsonStream = Utf8JsonHelper.ToStream(_testModel);
            _xmlStream = XmlHelper.ToStream(_testModel);
            _zeroFormatterStream = ZeroFormatterHelper.ToStream(_testModel);
        }

        [Benchmark]
        public void BinaryFromStream() => BinaryHelper.FromStream<TestModel>(_binaryStream);

        [Benchmark]
        public void JilFromStream() => JilHelper.FromStream<TestModel>(_jilStream);

        [Benchmark]
        public void MessagePackFromStream() => MessagePackHelper.FromStream<TestModel>(_messagePackStream);

        [Benchmark]
        public void MsgPackFromStream() => MsgPackHelper.FromStream<TestModel>(_msgPackStream);

        [Benchmark]
        public void NewtonsoftJsonFromStream() => NewtonsoftJsonHelper.FromStream<TestModel>(_newtonsoftJsonStream);

        [Benchmark]
        public void ProtobufFromStream() => ProtobufHelper.FromStream<TestModel>(_protobufStream);

        [Benchmark]
        public void SystemTextJsonFromStream() => SystemTextJsonHelper.FromStream<TestModel>(_systemTextJsonStream);

        [Benchmark]
        public void Utf8JsonFromStream() => Utf8JsonHelper.FromStream<TestModel>(_utf8JsonStream);

        [Benchmark]
        public void XmlFromStream() => XmlHelper.FromStream<TestModel>(_xmlStream);

        [Benchmark]
        public void ZeroFormatterFromStream() => ZeroFormatterHelper.FromStream<TestModel>(_zeroFormatterStream);
    }
}