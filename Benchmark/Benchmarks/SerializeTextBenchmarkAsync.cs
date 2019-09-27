using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Jil;
using Zaabee.NewtonsoftJson;
using Zaabee.SystemTextJson;
using Zaabee.Utf8Json;
using Zaabee.Xml;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class SerializeTextBenchmarkAsync
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
        public async Task JilSerializeToJsonAsync() =>
            await JilHelper.SerializeToJsonAsync(_testModel);

        [Benchmark]
        public async Task NewtonsoftJsonSerializeToJsonAsync() =>
            await NewtonsoftJsonHelper.SerializeToJsonAsync(_testModel);

        [Benchmark]
        public async Task Utf8JsonSerializeToJsonAsync() => await Utf8JsonHelper.SerializeToJsonAsync(_testModel);

        [Benchmark]
        public async Task SystemTextJsonSerializeToJsonAsync() =>
            await SystemTextJsonHelper.SerializeToJsonAsync(_testModel);

        [Benchmark]
        public async Task XmlSerializeToXmlAsync() =>
            await XmlHelper.SerializeToXmlAsync(_testModel);
    }
}