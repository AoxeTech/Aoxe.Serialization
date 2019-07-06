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
        public void ExtensionMethodTest()
        {
            var testModelGuid = GetTestModel();
            var bytes = testModelGuid.ToProtobuf();
            var deserializeModel1 = bytes.FromProtobuf<TestModel<Guid>>();

            Assert.Equal(deserializeModel1.Id, testModelGuid.Id);
            Assert.Equal(deserializeModel1.Age, testModelGuid.Age);
            Assert.Equal(deserializeModel1.CreateTime, testModelGuid.CreateTime);
            Assert.Equal(deserializeModel1.Name, testModelGuid.Name);
            Assert.Equal(deserializeModel1.Gender, testModelGuid.Gender);
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