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
    public class ToStreamAsync
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
        public async Task JilToStreamAsync() => await JilHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task MsgPackToStreamAsync() => await MsgPackHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task NewtonsoftJsonToStreamAsync() => await NewtonsoftJsonHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task SystemTextJsonToStreamAsync() => await SystemTextJsonHelper.PackAsync(_testModel);

        [Benchmark]
        public async Task Utf8JsonToStreamAsync() => await Utf8JsonHelper.PackAsync(_testModel);
    }
}