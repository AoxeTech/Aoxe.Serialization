using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.NewtonsoftJson;
using Zaabee.SystemTextJson;
using Zaabee.Utf8Json;
using Zaabee.Xml;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class DeserializeTextBenchmarkAsync
    {
        private readonly TestModel _testModel = new TestModel
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            CreateTime = new DateTime(2017, 1, 1),
            Name = "apple",
            Gender = Gender.Female
        };

        private readonly string _newtonsoftJson;
        private readonly string _systemTextJson;
        private readonly string _utf8Json;
        private readonly string _xml;

        public DeserializeTextBenchmarkAsync()
        {
            _newtonsoftJson = NewtonsoftJsonHelper.SerializeToJson(_testModel);
            _systemTextJson = SystemTextJsonHelper.SerializeToJson(_testModel);
            _utf8Json = Utf8JsonHelper.SerializeToJson(_testModel);
            _xml = XmlHelper.SerializeToXml(_testModel);
        }

        [Benchmark]
        public async Task NewtonsoftJsonDeserializeFromJsonAsync() =>
            await NewtonsoftJsonHelper.DeserializeAsync<TestModel>(_newtonsoftJson);

        [Benchmark]
        public async Task SystemTextJsonDeserializeFromJsonAsync() =>
            await SystemTextJsonHelper.DeserializeAsync<TestModel>(_systemTextJson);

        [Benchmark]
        public async Task Utf8JsonDeserializeFromJsonAsync() =>
            await Utf8JsonHelper.DeserializeAsync<TestModel>(_utf8Json);

        [Benchmark]
        public async Task XmlDeserializeFromXmlAsync() => await XmlHelper.DeserializeAsync<TestModel>(_xml);
    }
}