using System;
using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Jil;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.SystemTextJson;
using Zaabee.Utf8Json;

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

        private readonly Stream _jilStream;
        private readonly Stream _msgPackStream;
        private readonly Stream _newtonsoftJsonStream;
        private readonly Stream _systemTextJsonStream;
        private readonly Stream _utf8JsonStream;

        public UnpackBenchmarkAsync()
        {
            _jilStream = JilHelper.Pack(_testModel);
            _msgPackStream = MsgPackHelper.Pack(_testModel);
            _newtonsoftJsonStream = NewtonsoftJsonHelper.Pack(_testModel);
            _systemTextJsonStream = SystemTextJsonHelper.Pack(_testModel);
            _utf8JsonStream = Utf8JsonHelper.Pack(_testModel);
        }

        [Benchmark]
        public async Task JilUnpackAsync() => await JilHelper.UnpackAsync<TestModel>(_jilStream);

        [Benchmark]
        public async Task MsgPackUnpackAsync() => await MsgPackHelper.UnpackAsync<TestModel>(_msgPackStream);

        [Benchmark]
        public async Task NewtonsoftJsonUnpackAsync() =>
            await NewtonsoftJsonHelper.UnpackAsync<TestModel>(_newtonsoftJsonStream);

        [Benchmark]
        public async Task SystemTextJsonUnpackAsync() =>
            await SystemTextJsonHelper.UnpackAsync<TestModel>(_systemTextJsonStream);

        [Benchmark]
        public async Task Utf8JsonSerializeUnpackAsync() =>
            await Utf8JsonHelper.UnpackAsync<TestModel>(_utf8JsonStream);
    }
}