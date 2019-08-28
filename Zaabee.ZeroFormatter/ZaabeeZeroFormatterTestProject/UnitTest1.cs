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
            
            var bytes = testModel.Serialize();
            
            var stream1 = testModel.Pack();
            
            var stream2 = new MemoryStream();testModel.Pack(stream2);
            
            var stream3 = new MemoryStream();stream3.Pack(testModel);
            
            var deserializeResult = bytes.Deserialize<TestModel>();
            
            var unPackResult1 = stream1.UnPack<TestModel>();
            
            var unPackResult2 = stream2.UnPack<TestModel>();
            
            var unPackResult3 = stream3.UnPack<TestModel>();

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
            
            var bytes = testModel.Serialize(type);
            
            var stream1 = testModel.Pack(type);
            
            var stream2 = new MemoryStream();testModel.Pack(type,stream2);
            
            var stream3 = new MemoryStream();stream3.Pack(type,testModel);
            
            var deserializeResult = (TestModel)bytes.Deserialize(type);
            
            var unPackResult1 = (TestModel)stream1.UnPack(type);
            
            var unPackResult2 = (TestModel)stream2.UnPack(type);
            
            var unPackResult3 = (TestModel)stream3.UnPack(type);

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