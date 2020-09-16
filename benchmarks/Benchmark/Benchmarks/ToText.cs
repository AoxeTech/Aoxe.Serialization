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
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class ToText
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
        public void JilToText() => JilHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void NewtonsoftJsonToText() => NewtonsoftJsonHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void SystemTextJsonToText() => SystemTextJsonHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void Utf8JsonToText() => Utf8JsonHelper.SerializeToJson(_testModel);

        [Benchmark]
        public void XmlToText() => XmlHelper.SerializeToXml(_testModel);
    }
}