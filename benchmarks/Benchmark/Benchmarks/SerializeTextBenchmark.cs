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
    public class SerializeTextBenchmark
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
        public void JilSerializeToJson() => JilHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void NewtonsoftJsonSerializeToJson() => NewtonsoftJsonHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void SystemTextJsonSerializeToJson() => SystemTextJsonHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void Utf8JsonSerializeToJson() => Utf8JsonHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void XmlSerializeToXml() => XmlHelper.SerializeToXml(_testModel);
    }
}