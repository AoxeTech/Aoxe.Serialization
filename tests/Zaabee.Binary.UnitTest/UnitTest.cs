using System;
using System.IO;
using Xunit;
using Zaabee.Binary;

namespace Zaabee.Binary.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var testModel = GetTestModel();
            var bytes = testModel.ToBytes();
            var result0 = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

            Assert.Empty(BinaryHelper.Serialize(null));
            Assert.Null(BinaryHelper.Deserialize<TestModel>(null));
        }

        [Fact]
        public void StreamTest()
        {
            var testModel = GetTestModel();

            var stream1 = testModel.ToStream();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(testModel);

            var unPackResult1 = stream1.Unpack<TestModel>();
            var unPackResult2 = stream2.Unpack<TestModel>();
            var unPackResult3 = stream3.Unpack<TestModel>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));

            Assert.Equal(0, BinaryHelper.Pack(null).Length);
            Assert.Null(BinaryHelper.Unpack<TestModel>(null));
            var ms = new MemoryStream();
            BinaryHelper.Pack(null, ms);
            Assert.Equal(0, ms.Length);
            Assert.Equal(0, ms.Position);
        }

        [Fact]
        public void BytesNonGenericTest()
        {
            var testModel = GetTestModel();
            var bytes = testModel.ToBytes();
            var result = (TestModel) bytes.FromBytes();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void StreamNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = GetTestModel();

            var stream1 = testModel.ToStream();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(testModel);

            var unPackResult1 = (TestModel) stream1.Unpack(type);
            var unPackResult2 = (TestModel) stream2.Unpack(type);
            var unPackResult3 = (TestModel) stream3.Unpack(type);

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));
        }

        private static TestModel GetTestModel() =>
            new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1).ToUniversalTime(),
                Name = "apple",
                Gender = Gender.Female
            };
    }
}