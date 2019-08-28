using System;
using System.IO;
using Xunit;
using Zaabee.ZeroFormatter;

namespace ZaabeeZeroFormatterTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            var testModel = GetTestModel();
            
            var bytes = testModel.SerializeByZeroFormatter();
            
            var stream1 = testModel.PackByZeroFormatter();
            
            var stream2 = new MemoryStream();testModel.PackByZeroFormatter(stream2);
            
            var stream3 = new MemoryStream();stream3.PackByZeroFormatter(testModel);
            
            var deserializeResult = bytes.DeserializeByZeroFormatter<TestModel>();
            
            var unPackResult1 = stream1.UnPackByZeroFormatter<TestModel>();
            
            var unPackResult2 = stream2.UnPackByZeroFormatter<TestModel>();
            
            var unPackResult3 = stream3.UnPackByZeroFormatter<TestModel>();

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
            var type = typeof(TestModel);
            var testModel = GetTestModel();
            
            var bytes = testModel.SerializeByZeroFormatter(type);
            
            var stream1 = testModel.PackByZeroFormatter(type);
            
            var stream2 = new MemoryStream();testModel.PackByZeroFormatter(type,stream2);
            
            var stream3 = new MemoryStream();stream3.PackByZeroFormatter(type,testModel);
            
            var deserializeResult = (TestModel)bytes.DeserializeByZeroFormatter(type);
            
            var unPackResult1 = (TestModel)stream1.UnPackByZeroFormatter(type);
            
            var unPackResult2 = (TestModel)stream2.UnPackByZeroFormatter(type);
            
            var unPackResult3 = (TestModel)stream3.UnPackByZeroFormatter(type);

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

        private TestModel GetTestModel()
        {
            return new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1).ToUniversalTime(),
                Name = "apple",
                Gender = Gender.Female
            };
        }
    }
}