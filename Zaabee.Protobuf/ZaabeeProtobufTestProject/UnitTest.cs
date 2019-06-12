using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Zaabee.Protobuf;

namespace ZaabeeProtobufTestProject
{
    public class UnitTest
    {
        [Fact]
        public void ExtensionMethodTest()
        {
            var testModelGuid = GetTestModel();
            var bytes = testModelGuid.ToProtobuf();
            var deserializeModel1 = bytes.FromProtobuf<TestModel<Guid>>();
            var deserializeModel2 = bytes.FromProtobuf(typeof(TestModel<Guid>)) as TestModel<Guid>;

            Assert.Equal(deserializeModel1.Id, testModelGuid.Id);
            Assert.Equal(deserializeModel1.Age, testModelGuid.Age);
            Assert.Equal(deserializeModel1.CreateTime, testModelGuid.CreateTime);
            Assert.Equal(deserializeModel1.Name, testModelGuid.Name);
            Assert.Equal(deserializeModel1.Gender, testModelGuid.Gender);

            Assert.Equal(deserializeModel2.Id, testModelGuid.Id);
            Assert.Equal(deserializeModel2.Age, testModelGuid.Age);
            Assert.Equal(deserializeModel2.CreateTime, testModelGuid.CreateTime);
            Assert.Equal(deserializeModel2.Name, testModelGuid.Name);
            Assert.Equal(deserializeModel2.Gender, testModelGuid.Gender);
        }

        [Fact]
        public void ExtensionMethodWithoutAttrTest()
        {
            var testModelWithoutAttr = GetTestModelWithoutAttr();
            var bytes = testModelWithoutAttr.ToProtobuf();
            var deserializeModel1 = bytes.FromProtobuf<TestModelWithoutAttr>();
            var deserializeModel2 = bytes.FromProtobuf(typeof(TestModelWithoutAttr)) as TestModelWithoutAttr;

            Assert.Equal(deserializeModel1.Id, testModelWithoutAttr.Id);
            Assert.Equal(deserializeModel1.Age, testModelWithoutAttr.Age);
            Assert.Equal(deserializeModel1.CreateTime, testModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel1.Name, testModelWithoutAttr.Name);
            Assert.Equal(deserializeModel1.Gender, testModelWithoutAttr.Gender);
            Assert.Equal(deserializeModel1.Kids.Count, testModelWithoutAttr.Kids.Count);
            Assert.True(deserializeModel1.Kids.Keys.All(p => testModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel1.Kids.Values.All(p => testModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));

            Assert.Equal(deserializeModel2.Id, testModelWithoutAttr.Id);
            Assert.Equal(deserializeModel2.Age, testModelWithoutAttr.Age);
            Assert.Equal(deserializeModel2.CreateTime, testModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel2.Name, testModelWithoutAttr.Name);
            Assert.Equal(deserializeModel2.Gender, testModelWithoutAttr.Gender);
            Assert.True(deserializeModel2.Kids.Keys.All(p => testModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel2.Kids.Values.All(p => testModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));
        }

        [Fact]
        public void ExtensionMethodWithoutAttrForSubTest()
        {
            var testSubModelWithoutAttr = GetTestSubModelWithoutAttr();
            var bytes = testSubModelWithoutAttr.ToProtobuf();
            var deserializeModel1 = bytes.FromProtobuf<TestSubModelWithoutAttr>();
            var deserializeModel2 = bytes.FromProtobuf(typeof(TestSubModelWithoutAttr)) as TestSubModelWithoutAttr;

            Assert.Equal(deserializeModel1.Id, testSubModelWithoutAttr.Id);
            Assert.Equal(deserializeModel1.Age, testSubModelWithoutAttr.Age);
            Assert.Equal(deserializeModel1.CreateTime, testSubModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel1.Name, testSubModelWithoutAttr.Name);
            Assert.Equal(deserializeModel1.Gender, testSubModelWithoutAttr.Gender);
            Assert.True(deserializeModel1.Kids.Keys.All(p => testSubModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel1.Kids.Values.All(p => testSubModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));

            Assert.Equal(deserializeModel2.Id, testSubModelWithoutAttr.Id);
            Assert.Equal(deserializeModel2.Age, testSubModelWithoutAttr.Age);
            Assert.Equal(deserializeModel2.CreateTime, testSubModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel2.Name, testSubModelWithoutAttr.Name);
            Assert.Equal(deserializeModel2.Gender, testSubModelWithoutAttr.Gender);
            Assert.True(deserializeModel2.Kids.Keys.All(p => testSubModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel2.Kids.Values.All(p => testSubModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));
        }

        [Fact]
        public void HelperTest()
        {
            var testModelWithoutAttr = GetTestModelWithoutAttr();
            var i1 = testModelWithoutAttr.ToProtobuf();
            var i2 = i1.FromProtobuf<TestModelWithoutAttr>();
            var testSubModelWithoutAttr = GetTestSubModelWithoutAttr();

            var stream = new MemoryStream();
            ProtobufHelper.Serialize(stream, testSubModelWithoutAttr);
            var i = ProtobufHelper.Deserialize(stream, typeof(TestSubModelWithoutAttr));
            var deserializeModel = (TestSubModelWithoutAttr) i;

            Assert.Equal(deserializeModel.Id, testSubModelWithoutAttr.Id);
            Assert.Equal(deserializeModel.Age, testSubModelWithoutAttr.Age);
            Assert.Equal(deserializeModel.CreateTime, testSubModelWithoutAttr.CreateTime);
            Assert.Equal(deserializeModel.Name, testSubModelWithoutAttr.Name);
            Assert.Equal(deserializeModel.Gender, testSubModelWithoutAttr.Gender);
            Assert.True(deserializeModel.Kids.Keys.All(p => testSubModelWithoutAttr.Kids.Keys.Any(q => q == p)));
            Assert.True(deserializeModel.Kids.Values.All(p => testSubModelWithoutAttr.Kids.Values.Any(q =>
                q.Id == p.Id && q.Age == p.Age && q.CreateTime == p.CreateTime && q.Name == p.Name &&
                q.Gender == p.Gender)));
        }
        
        private TestModel<Guid> GetTestModel()
        {
            return new TestModel<Guid>
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1),
                Name = "banana",
                Gender = Gender.Female
            };
        }
        
        private TestModelWithoutAttr GetTestModelWithoutAttr()
        {
            return new TestModelWithoutAttr
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
        }

        private TestSubModelWithoutAttr GetTestSubModelWithoutAttr()
        {
            return new TestSubModelWithoutAttr
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
    }
}