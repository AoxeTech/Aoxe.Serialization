using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ProtoBuf;
using Zaabee.Binary;
using Zaabee.Jil;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.Protobuf;
using Zaabee.Utf8Json;
using Zaabee.Xml;
using Zaabee.ZeroFormatter;
using ZeroFormatter;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchMarkTest>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class BenchMarkTest
    {
        private TestModel _testModel;
        private readonly byte[] _binary;
        private readonly string _jil;
        private readonly string _json;
        private readonly byte[] _msgPackBytes;
        private readonly string _utf8JsonString;
        private readonly byte[] _utf8JsonBytes;
        private readonly byte[] _protobuf;
        private readonly string _xml;
        private readonly byte[] _zeroFormatterBytes;

        public BenchMarkTest()
        {
            InitTestModel();
            _binary = _testModel.ToBytes();
            _jil = _testModel.ToJil();
            _json = _testModel.ToJson();
            _msgPackBytes = _testModel.ToMsgPack();
            _utf8JsonString = _testModel.Utf8JsonToString();
            _utf8JsonBytes = _testModel.Utf8JsonToBytes();
            _protobuf = _testModel.ToProtobuf();
            _xml = _testModel.ToXml();
            _zeroFormatterBytes = _testModel.ToZeroFormatter();
        }

        [Benchmark]
        public void BinarySerialize()
        {
            var bytes = _testModel.ToBytes();
        }

        [Benchmark]
        public void JilSerialize()
        {
            var jil = _testModel.ToJil();
        }

        [Benchmark]
        public void NewtonJsonSerialize()
        {
            var json = _testModel.ToJson();
        }

        [Benchmark]
        public void MsgPackSerialize()
        {
            var json = _testModel.ToMsgPack();
        }

        [Benchmark]
        public void Utf8JsonSerializeString()
        {
            var json = _testModel.Utf8JsonToString();
        }

        [Benchmark]
        public void Utf8JsonSerializeBytes()
        {
            var bytes = _testModel.Utf8JsonToBytes();
        }

        [Benchmark]
        public void ProtobufSerialize()
        {
            var protobuf = _testModel.ToProtobuf();
        }

        [Benchmark]
        public void XmlSerialize()
        {
            var xml = _testModel.ToXml();
        }

        [Benchmark]
        public void ZeroFormatterSerialize()
        {
            var bytes = _testModel.ToZeroFormatter();
        }

        [Benchmark]
        public void BinaryDeserialize()
        {
            var model = _binary.FromBytes<TestModel>();
        }

        [Benchmark]
        public void JilDeserialize()
        {
            var model = _jil.FromJil<TestModel>();
        }

        [Benchmark]
        public void NewtonJsonDeserialize()
        {
            var model = _json.FromJson<TestModel>();
        }

        [Benchmark]
        public void MsgPackDeserialize()
        {
            var model = _msgPackBytes.FromMsgPak<TestModel>();
        }

        [Benchmark]
        public void Utf8JsonDeserializeString()
        {
            var model = _utf8JsonString.FromUtf8Json<TestModel>();
        }

        [Benchmark]
        public void Utf8JsonDeserializeBytes()
        {
            var model = _utf8JsonBytes.FromUtf8Json<TestModel>();
        }

        [Benchmark]
        public void ProtobufDeserialize()
        {
            var model = _protobuf.FromProtobuf<TestModel>();
        }

        [Benchmark]
        public void XmlDeserialize()
        {
            var model = _xml.FromXml<TestModel>();
        }

        [Benchmark]
        public void ZeroFormatterDeserialize()
        {
            var model = _zeroFormatterBytes.FromZeroFormatter<TestModel>();
        }

        private void InitTestModel()
        {
            _testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1),
                Name = "apple",
                Gender = Gender.Female
            };
        }
    }

    [Serializable]
    [ProtoContract]
    [ZeroFormattable]
    public class TestModel
    {
        [ProtoMember(1)] [Index(0)] public virtual Guid Id { get; set; }
        [ProtoMember(2)] [Index(1)] public virtual int Age { get; set; }
        [ProtoMember(3)] [Index(2)] public virtual string Name { get; set; }
        [ProtoMember(4)] [Index(3)] public virtual DateTime CreateTime { get; set; }
        [ProtoMember(5)] [Index(4)] public virtual Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}