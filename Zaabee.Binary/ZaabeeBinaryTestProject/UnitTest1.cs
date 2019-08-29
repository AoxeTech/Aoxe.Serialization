using System;
using System.IO;
using Xunit;
using Zaabee.Binary;

namespace ZaabeeBinaryTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            var testModel = GetTestModel();

            var bytes = testModel.ToBytes();

            var stream1 = testModel.ToStream();

            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);

            var stream3 = new MemoryStream();
            stream3.Pack(testModel);

            var deserializeResult = bytes.FromBytes<TestModel>();

            var unPackResult1 = stream1.Unpack<TestModel>();

            var unPackResult2 = stream2.Unpack<TestModel>();

            var unPackResult3 = stream3.Unpack<TestModel>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(deserializeResult.Id, deserializeResult.Age, deserializeResult.CreateTime,
                    deserializeResult.Name));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name));
        }

        [Fact]
        public void NonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = GetTestModel();

            var bytes = testModel.ToBytes();

            var stream1 = testModel.ToStream();

            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);

            var stream3 = new MemoryStream();
            stream3.Pack(testModel);

            var deserializeResult = (TestModel) bytes.FromBytes(type);

            var unPackResult1 = (TestModel) stream1.Unpack(type);

            var unPackResult2 = (TestModel) stream2.Unpack(type);

            var unPackResult3 = (TestModel) stream3.Unpack(type);

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(deserializeResult.Id, deserializeResult.Age, deserializeResult.CreateTime,
                    deserializeResult.Name));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name));
        }

        private TestModel GetTestModel()
        {
            return new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1).ToUniversalTime(),
                Name = "apple"
            };
        }
    }
}