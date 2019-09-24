using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Jil;
using Zaabee.NewtonsoftJson;
using Zaabee.SwifterJson;
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

        private readonly string _jil;
        private readonly string _newtonsoftJson;
        private readonly string _swifterJson;
        private readonly string _utf8Json;
        private readonly string _xml;

        public DeserializeTextBenchmarkAsync()
        {
            _jil = JilHelper.SerializeToJson(_testModel);
            _newtonsoftJson = NewtonsoftJsonHelper.SerializeToJson(_testModel);
            _swifterJson = SwifterJsonHelper.SerializeToJson(_testModel);
            _utf8Json = Utf8JsonHelper.SerializeToJson(_testModel);
            _xml = XmlHelper.SerializeToXml(_testModel);
        }

        [Benchmark]
        public async Task JilDeserializeFromJsonAsync() => await JilHelper.DeserializeAsync<TestModel>(_jil);

        [Benchmark]
        public async Task NewtonsoftJsonDeserializeFromJsonAsync() =>
            await NewtonsoftJsonHelper.DeserializeAsync<TestModel>(_newtonsoftJson);

        [Benchmark]
        public async Task Utf8JsonDeserializeFromJsonAsync() =>
            await Utf8JsonHelper.DeserializeAsync<TestModel>(_utf8Json);

        [Benchmark]
        public async Task XmlDeserializeFromXmlAsync() => await XmlHelper.DeserializeAsync<TestModel>(_xml);
    }
}