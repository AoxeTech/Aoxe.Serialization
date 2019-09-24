using System;
using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Binary;
using Zaabee.Jil;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.Protobuf;
using Zaabee.SwifterJson;
using Zaabee.Utf8Json;
using Zaabee.Xml;
using Zaabee.ZeroFormatter;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class UnpackBenchmarkAsync
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
        private readonly Stream _swifterJsonStream;
        private readonly Stream _utf8JsonStream;
        private readonly Stream _xmlStream;
        private readonly Stream _zeroFormatterStream;

        public UnpackBenchmarkAsync()
        {
            _binaryStream = BinaryHelper.Pack(_testModel);
            _jilStream = JilHelper.Pack(_testModel);
            _msgPackStream = MsgPackHelper.Pack(_testModel);
            _newtonsoftJsonStream = NewtonsoftJsonHelper.Pack(_testModel);
            _protobufStream = ProtobufHelper.Pack(_testModel);
            _swifterJsonStream = SwifterJsonHelper.Pack(_testModel);
            _utf8JsonStream = Utf8JsonHelper.Pack(_testModel);
            _xmlStream = XmlHelper.Pack(_testModel);
            _zeroFormatterStream = ZeroFormatterHelper.Pack(_testModel);
        }

        [Benchmark]
        public async Task JilUnpackAsync() => await JilHelper.UnpackAsync<TestModel>(_jilStream);

        [Benchmark]
        public async Task MsgPackUnpackAsync() => await MsgPackHelper.UnpackAsync<TestModel>(_msgPackStream);

        [Benchmark]
        public async Task NewtonsoftJsonUnpackAsync() =>
            await NewtonsoftJsonHelper.UnpackAsync<TestModel>(_newtonsoftJsonStream);

        [Benchmark]
        public async Task ProtobufUnpackAsync() => await ProtobufHelper.UnpackAsync<TestModel>(_protobufStream);

        [Benchmark]
        public async Task Utf8JsonSerializeUnpackAsync() =>
            await Utf8JsonHelper.UnpackAsync<TestModel>(_utf8JsonStream);

        [Benchmark]
        public async Task XmlUnpackAsync() => await XmlHelper.UnpackAsync<TestModel>(_xmlStream);

        [Benchmark]
        public async Task ZeroFormatterUnpackAsync() =>
            await ZeroFormatterHelper.UnpackAsync<TestModel>(_zeroFormatterStream);
    }
}