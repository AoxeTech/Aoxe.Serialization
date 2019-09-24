using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Zaabee.ZeroFormatter;

namespace ZaabeeZeroFormatterTestProject
{
    public class UnitTestAsync
    {
        [Fact]
        public async Task BytesTest()
        {
            var testModel = GetTestModel();
            var bytes = await testModel.ToBytesAsync();
            var result = await bytes.FromBytesAsync<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public async Task StreamTest()
        {
            var testModel = GetTestModel();

            var stream1 = await testModel.ToStreamAsync();
            var stream2 = new MemoryStream();
            await testModel.PackToAsync(stream2);
            var stream3 = new MemoryStream();
            await stream3.PackByAsync(testModel);

            var unPackResult1 = await stream1.UnpackAsync<TestModel>();
            var unPackResult2 = await stream2.UnpackAsync<TestModel>();
            var unPackResult3 = await stream3.UnpackAsync<TestModel>();

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

        [Fact]
        public async Task BytesNonGenericTest()
        {
            var testModel = GetTestModel();
            var bytes = await testModel.ToBytesAsync();
            var result = (TestModel) await bytes.FromBytesAsync(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public async Task StreamNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = GetTestModel();

            var stream1 = await testModel.ToStreamAsync(type);
            var stream2 = new MemoryStream();
            await testModel.PackToAsync(type, stream2);
            var stream3 = new MemoryStream();
            await stream3.PackByAsync(type, testModel);

            var unPackResult1 = (TestModel) await stream1.UnpackAsync(type);
            var unPackResult2 = (TestModel) await stream2.UnpackAsync(type);
            var unPackResult3 = (TestModel) await stream3.UnpackAsync(type);

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

        private static TestModel GetTestModel()
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