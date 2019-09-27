using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Binary;
using Zaabee.Jil;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.Protobuf;
using Zaabee.SwifterJson;
using Zaabee.SystemTextJson;
using Zaabee.Utf8Json;
using Zaabee.Xml;
using Zaabee.ZeroFormatter;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class DeserializeBenchmarkAsync
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
        private readonly byte[] _swifterJsonBytes;
        private readonly byte[] _systemTextJsonBytes;
        private readonly byte[] _utf8JsonBytes;
        private readonly byte[] _xmlBytes;
        private readonly byte[] _zeroFormatterBytes;

        public DeserializeBenchmarkAsync()
        {
            _binaryBytes = BinaryHelper.Serialize(_testModel);
            _jilBytes = JilHelper.Serialize(_testModel);
            _msgPackBytes = MsgPackHelper.Serialize(_testModel);
            _newtonsoftJsonBytes = NewtonsoftJsonHelper.Serialize(_testModel);
            _protobufBytes = ProtobufHelper.Serialize(_testModel);
            _swifterJsonBytes = SwifterJsonHelper.Serialize(_testModel);
            _systemTextJsonBytes = SystemTextJsonHelper.Serialize(_testModel);
            _utf8JsonBytes = Utf8JsonHelper.Serialize(_testModel);
            _xmlBytes = XmlHelper.Serialize(_testModel);
            _zeroFormatterBytes = ZeroFormatterHelper.Serialize(_testModel);
        }

        [Benchmark]
        public async Task JilDeserializeAsync() =>
            await JilHelper.DeserializeAsync<TestModel>(_jilBytes);

        [Benchmark]
        public async Task MsgPackDeserializeAsync() =>
            await MsgPackHelper.DeserializeAsync<TestModel>(_msgPackBytes);

        [Benchmark]
        public async Task NewtonsoftJsonDeserializeAsync() =>
            await NewtonsoftJsonHelper.DeserializeAsync<TestModel>(_newtonsoftJsonBytes);

        [Benchmark]
        public async Task ProtobufDeserializeAsync() =>
            await ProtobufHelper.DeserializeAsync<TestModel>(_protobufBytes);

        [Benchmark]
        public async Task SystemTextJsonDeserializeAsync() =>
            await SystemTextJsonHelper.DeserializeAsync<TestModel>(_systemTextJsonBytes);

        [Benchmark]
        public async Task Utf8JsonSerializeDeserializeAsync() =>
            await Utf8JsonHelper.DeserializeAsync<TestModel>(_utf8JsonBytes);

        [Benchmark]
        public async Task XmlDeserializeAsync() => await XmlHelper.DeserializeAsync<TestModel>(_xmlBytes);

        [Benchmark]
        public async Task ZeroFormatterDeserializeAsync() =>
            await ZeroFormatterHelper.DeserializeAsync<TestModel>(_zeroFormatterBytes);
    }
}