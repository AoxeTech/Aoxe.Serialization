using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Zaabee.Protobuf;

namespace UnitTest
{
    public class UnitTest
    {
        private static TestModel _testModel;
        private static TestModelWithoutAttr _testModelWithoutAttr;
        private static TestSubModelWithoutAttr _testSubModelWithoutAttr;

        public UnitTest()
        {
            _testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1),
                Name = "banana",
                Gender = Gender.Female
            };

            _testModelWithoutAttr = new TestModelWithoutAttr
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1),
                Name = "apple",
                Gender = Gender.Female,
                Kids = new Dictionary<Guid, TestModelWithoutAttr>
                {
                    {
                        Guid.NewGuid(),
                        new TestModelWithoutAttr
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

            _testSubModelWithoutAttr = new TestSubModelWithoutAttr
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1),
                Name = "apple",
                Gender = Gender.Female,
                LongId = long.MaxValue,
                Kids = new Dictionary<Guid, TestModelWithoutAttr>
                {
                    {
                        Guid.NewGuid(), new TestSubModelWithoutAttr
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "apple",
                            Gender = Gender.Female,
                            LongId = long.MaxValue
                        }
                    },
                    {
                        Guid.NewGuid(), new TestSubModelWithoutAttr
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "apple",
                            Gender = Gender.Female,
                            LongId = long.MaxValue
                        }
                    },
                    {
                        Guid.NewGuid(), new TestSubModelWithoutAttr
                        {
                            Id = Guid.NewGuid(),
                            Age = new Random().Next(0, 100),
                            CreateTime = new DateTime(2017, 1, 1),
                            Name = "apple",
                            Gender = Gender.Female,
                            LongId = long.MaxValue
                        }
                    }
                }
            };
        }

        [Fact]
        public void ExtensionMethodTest()
        {
            var bytes = _testModel.ToProtobuf();
            var deserializeModel1 = bytes.FromProtobuf<TestModel>();
            var deserializeModel2 = bytes.FromProtobuf(typeof(TestModel)) as TestModel;

            Assert.Equal(deserializeModel1.Id, _testModel.Id);
            Assert.Equal(deserializeModel1.Age, _testModel.Age);
            Assert.Equal(deserializeModel1.CreateTime, _testModel.CreateTime);
            Assert.Equal(deserializeModel1.Name, _testModel.Name);
            Assert.Equal(deserializeModel1.Gender, _testModel.Gender);

            Assert.Equal(deserializeModel2.Id, _testModel.Id);
            Assert.Equal(deserializeModel2.Age, _testModel.Age);
            Assert.Equal(deserializeModel2.CreateTime, _testModel.CreateTime);
            Assert.Equal(deserializeModel2.Name, _testModel.Name);
            Assert.Equal(deserializeModel2.Gender, _testModel.Gender);
        }

        [Fact]
        public void ExtensionMethodWithoutAttrTest()
        {
            var bytes = _testModelWithoutAttr.ToProtobuf();
            var deserializeModel1 = bytes.FromProtobuf<TestModelWithoutAttr>();
            var deserializeModel2 = bytes.FromProtobuf(typeof(TestModelWithoutAttr)) as TestModelWithoutAttr;

            Assert.Equal(deserializeModel1.Id, _testModelWithoutAttr.Id);
            Assert.Equal(deserializeModel1.Age, _testModelWithoutAttr.Age);
            Assert.Equal(deserializeModel1.CreateTime, _testModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel1.Name, _testModelWithoutAttr.Name);
            Assert.Equal(deserializeModel1.Gender, _testModelWithoutAttr.Gender);
            Assert.Equal(deserializeModel1.Kids.Count, _testModelWithoutAttr.Kids.Count);
            Assert.True(deserializeModel1.Kids.Keys.All(p => _testModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel1.Kids.Values.All(p => _testModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));

            Assert.Equal(deserializeModel2.Id, _testModelWithoutAttr.Id);
            Assert.Equal(deserializeModel2.Age, _testModelWithoutAttr.Age);
            Assert.Equal(deserializeModel2.CreateTime, _testModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel2.Name, _testModelWithoutAttr.Name);
            Assert.Equal(deserializeModel2.Gender, _testModelWithoutAttr.Gender);
            Assert.True(deserializeModel2.Kids.Keys.All(p => _testModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel2.Kids.Values.All(p => _testModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));
        }

        [Fact]
        public void ExtensionMethodWithoutAttrForSubTest()
        {
            var bytes = _testSubModelWithoutAttr.ToProtobuf();
            var deserializeModel1 = bytes.FromProtobuf<TestSubModelWithoutAttr>();
            var deserializeModel2 = bytes.FromProtobuf(typeof(TestSubModelWithoutAttr)) as TestSubModelWithoutAttr;

            Assert.Equal(deserializeModel1.Id, _testSubModelWithoutAttr.Id);
            Assert.Equal(deserializeModel1.Age, _testSubModelWithoutAttr.Age);
            Assert.Equal(deserializeModel1.CreateTime, _testSubModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel1.Name, _testSubModelWithoutAttr.Name);
            Assert.Equal(deserializeModel1.Gender, _testSubModelWithoutAttr.Gender);
            Assert.True(deserializeModel1.Kids.Keys.All(p => _testSubModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel1.Kids.Values.All(p => _testSubModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));

            Assert.Equal(deserializeModel2.Id, _testSubModelWithoutAttr.Id);
            Assert.Equal(deserializeModel2.Age, _testSubModelWithoutAttr.Age);
            Assert.Equal(deserializeModel2.CreateTime, _testSubModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel2.Name, _testSubModelWithoutAttr.Name);
            Assert.Equal(deserializeModel2.Gender, _testSubModelWithoutAttr.Gender);
            Assert.True(deserializeModel2.Kids.Keys.All(p => _testSubModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel2.Kids.Values.All(p => _testSubModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));
        }
    }
}