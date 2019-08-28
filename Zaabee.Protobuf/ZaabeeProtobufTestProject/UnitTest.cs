using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProtoBuf.Meta;
using Xunit;
using Zaabee.Protobuf;

namespace ZaabeeProtobufTestProject
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            var testModel = GetTestModel();
            
            var bytes = testModel.ToProtobuf();
            
            var stream1 = testModel.PackProtobuf();
            
            var stream2 = new MemoryStream();testModel.PackProtobuf(stream2);
            
            var stream3 = new MemoryStream();stream3.PackProtobuf(testModel);
            
            var deserializeResult = bytes.FromProtobuf<TestModel<Guid>>();
            
            var unPackResult1 = stream1.UnpackProtobuf<TestModel<Guid>>();
            
            var unPackResult2 = stream2.UnpackProtobuf<TestModel<Guid>>();
            
            var unPackResult3 = stream3.UnpackProtobuf<TestModel<Guid>>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(deserializeResult.Id, deserializeResult.Age, deserializeResult.CreateTime, deserializeResult.Name, deserializeResult.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name, unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name, unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name, unPackResult3.Gender));
        }
        [Fact]
        public void NonGenericTest()
        {
            var type = typeof(TestModel<Guid>);
            var testModel = GetTestModel();
            
            var bytes = testModel.ToProtobuf();
            
            var stream1 = testModel.PackProtobuf();
            
            var stream2 = new MemoryStream();testModel.PackProtobuf(stream2);
            
            var stream3 = new MemoryStream();stream3.PackProtobuf(testModel);
            
            var deserializeResult = (TestModel<Guid>)bytes.FromProtobuf(type);
            
            var unPackResult1 = (TestModel<Guid>)stream1.UnpackProtobuf(type);
            
            var unPackResult2 = (TestModel<Guid>)stream2.UnpackProtobuf(type);
            
            var unPackResult3 = (TestModel<Guid>)stream3.UnpackProtobuf(type);

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(deserializeResult.Id, deserializeResult.Age, deserializeResult.CreateTime, deserializeResult.Name, deserializeResult.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name, unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name, unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name, unPackResult3.Gender));
        }

        [Fact]
        public void SerializerBuilderTest()
        {
            var testModelWithoutAttr = GetTestSubModelWithoutAttr();

            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            SerializerBuilder.Build<TestSubModelWithoutAttr>(typeModel);

            var ms = new MemoryStream();
            typeModel.Serialize(ms, testModelWithoutAttr);
            var bytes = ms.ToArray();

            var deserializeModel1 =
                (TestSubModelWithoutAttr) typeModel.Deserialize(new MemoryStream(bytes), null,
                    typeof(TestSubModelWithoutAttr));

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