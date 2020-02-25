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

        private readonly FileStream _jilStream = new FileStream(".\\JilStream", FileMode.Create);
        private readonly FileStream _msgPackStream = new FileStream(".\\MsgPackStream", FileMode.Create);
        private readonly FileStream _newtonsoftJsonStream = new FileStream(".\\NewtonsoftJsonStream", FileMode.Create);
        private readonly FileStream _systemTextJsonStream = new FileStream(".\\SystemTextJsonStream", FileMode.Create);
        private readonly FileStream _utf8JsonStream = new FileStream(".\\Utf8JsonStream", FileMode.Create);

        public UnpackBenchmarkAsync()
        {
            JilHelper.Pack(_testModel, _jilStream);
            MsgPackHelper.Pack(_testModel, _msgPackStream);
            NewtonsoftJsonHelper.Pack(_testModel, _newtonsoftJsonStream);
            SystemTextJsonHelper.Pack(_testModel, _systemTextJsonStream);
            Utf8JsonHelper.Pack(_testModel, _utf8JsonStream);
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
        public async Task Utf8JsonUnpackAsync() => await Utf8JsonHelper.UnpackAsync<TestModel>(_utf8JsonStream);
    }
}