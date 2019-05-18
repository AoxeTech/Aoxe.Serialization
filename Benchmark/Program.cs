using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Zaabee.Jil;
using Zaabee.NewtonsoftJson;
using Zaabee.Protobuf;
using Zaabee.Xml;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchMarkTest>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class BenchMarkTest
    {
        private List<TestModel> _testModels;
        private readonly string _jil;
        private readonly string _json;
        private readonly byte[] _protobuf;
        private readonly string _xml;

        public BenchMarkTest()
        {
            InitTestModel();
            _jil = _testModels.ToJil();
            _json = _testModels.ToJson();
            _protobuf = _testModels.ToProtobuf();
            _xml = _testModels.ToXml();
        }

        [Benchmark]
        public void JilSerialize()
        {
            var jil = _testModels.ToJil();
        }

        [Benchmark]
        public void JsonSerialize()
        {
            var json = _testModels.ToJson();
        }

        [Benchmark]
        public void ProtobufSerialize()
        {
            var protobuf = _testModels.ToProtobuf();
        }

        [Benchmark]
        public void XmlSerialize()
        {
            var xml = _testModels.ToXml();
        }

        [Benchmark]
        public void JilDeserialize()
        {
            var model = _jil.FromJil<List<TestModel>>();
        }

        [Benchmark]
        public void JsonDeserialize()
        {
            var model = _json.FromJson<List<TestModel>>();
        }

        [Benchmark]
        public void ProtobufDeserialize()
        {
            var model = _protobuf.FromProtobuf<List<TestModel>>();
        }

        [Benchmark]
        public void XmlDeserialize()
        {
            var model = _xml.FromXml<List<TestModel>>();
        }

        private void InitTestModel()
        {
            _testModels = new List<TestModel>
            {
                new TestModel
                {
                    Id = Guid.NewGuid(),
                    Age = new Random().Next(0, 100),
                    CreateTime = new DateTime(2017, 1, 1),
                    Name = "apple",
                    Gender = Gender.Female,
                    Kids = new List<TestModel>
                    {
                        new TestModel
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "pear",
                            Gender = Gender.Female
                        },
                        new TestModel
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "pear",
                            Gender = Gender.Female
                        },
                        new TestModel
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "pear",
                            Gender = Gender.Female
                        },
                        new TestModel
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "pear",
                            Gender = Gender.Female
                        },
                        new TestModel
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "pear",
                            Gender = Gender.Female
                        }
                    }
                }
            };
        }
    }

    public class TestModel
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public Gender Gender { get; set; }
        public List<TestModel> Kids { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}