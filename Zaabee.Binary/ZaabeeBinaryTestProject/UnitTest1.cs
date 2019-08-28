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

            var bytes = testModel.ToBinary();

            var stream1 = testModel.PackBinary();

            var stream2 = new MemoryStream();
            testModel.PackBinary(stream2);

            var stream3 = new MemoryStream();
            stream3.PackBinary(testModel);

            var deserializeResult = bytes.FromBinary<TestModel>();

            var unPackResult1 = stream1.UnpackBinary<TestModel>();

            var unPackResult2 = stream2.UnpackBinary<TestModel>();

            var unPackResult3 = stream3.UnpackBinary<TestModel>();

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

            var bytes = testModel.ToBinary();

            var stream1 = testModel.PackBinary();

            var stream2 = new MemoryStream();
            testModel.PackBinary(stream2);

            var stream3 = new MemoryStream();
            stream3.PackBinary(testModel);

            var deserializeResult = (TestModel) bytes.FromBinary(type);

            var unPackResult1 = (TestModel) stream1.UnpackBinary(type);

            var unPackResult2 = (TestModel) stream2.UnpackBinary(type);

            var unPackResult3 = (TestModel) stream3.UnpackBinary(type);

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