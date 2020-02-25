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
    public class PackBenchmarkAsync
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
        public async Task JilPackAsync() => await JilHelper.PackAsync(_testModel, new FileStream(".\\JilPackAsync", FileMode.Create));

        [Benchmark]
        public async Task MsgPackPackAsync() => await MsgPackHelper.PackAsync(_testModel, new FileStream(".\\MsgPackPackAsync", FileMode.Create));

        [Benchmark]
        public async Task NewtonsoftJsonPackAsync() => await NewtonsoftJsonHelper.PackAsync(_testModel, new FileStream(".\\NewtonsoftJsonPackAsync", FileMode.Create));

        [Benchmark]
        public async Task SystemTextJsonPackAsync() => await SystemTextJsonHelper.PackAsync(_testModel, new FileStream(".\\SystemTextJsonPackAsync", FileMode.Create));

        [Benchmark]
        public async Task Utf8JsonPackAsync() => await Utf8JsonHelper.PackAsync(_testModel, new FileStream(".\\Utf8JsonPackAsync", FileMode.Create));
    }
}