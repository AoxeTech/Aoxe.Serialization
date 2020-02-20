using System;
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
    [SimpleJob(RunStrategy.Monitoring, targetCount: 10000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class DeserializeTextBenchmark
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
        private readonly string _systemTextJson;
        private readonly string _utf8Json;
        private readonly string _xml;

        public DeserializeTextBenchmark()
        {
            _jil = JilHelper.SerializeToJson(_testModel);
            _newtonsoftJson = NewtonsoftJsonHelper.SerializeToJson(_testModel);
            _systemTextJson = SystemTextJsonHelper.SerializeToJson(_testModel);
            _utf8Json = Utf8JsonHelper.SerializeToJson(_testModel);
            _xml = XmlHelper.SerializeToXml(_testModel);
        }

        [Benchmark]
        public void JilDeserializeFromJson() => JilHelper.Deserialize<TestModel>(_jil);

        [Benchmark]
        public void NewtonsoftJsonDeserializeFromJson() => NewtonsoftJsonHelper.Deserialize<TestModel>(_newtonsoftJson);

        [Benchmark]
        public void SystemTextJsonDeserializeFromJson() => SystemTextJsonHelper.Deserialize<TestModel>(_systemTextJson);

        [Benchmark]
        public void Utf8JsonDeserializeFromJson() => Utf8JsonHelper.Deserialize<TestModel>(_utf8Json);

        [Benchmark]
        public void XmlDeserializeFromXml() => XmlHelper.Deserialize<TestModel>(_xml);
    }
}