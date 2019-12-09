using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Zaabee.SystemTextJson;

namespace ZaabeeSystemTextJsonTestProject
{
    public class UnitTestAsync
    {
        [Fact]
        public async Task StreamTest()
        {
            var testModel = GetTestModel();
            var stream2 = new MemoryStream();
            await testModel.PackToAsync(stream2);
            var stream3 = new MemoryStream();
            await stream3.PackByAsync(testModel);
            var unPackResult2 = await stream2.UnpackAsync<TestModel>();
            var unPackResult3 = await stream3.UnpackAsync<TestModel>();

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
        public async Task StreamNonGenericTest()
        {
            var type = typeof(TestModel);
            object testModel = GetTestModel();

            var stream2 = new MemoryStream();
            await testModel.PackToAsync(type, stream2);
            var stream3 = new MemoryStream();
            await stream3.PackByAsync(type, testModel);

            var unPackResult2 = (TestModel) await stream2.UnpackAsync(type);
            var unPackResult3 = (TestModel) await stream3.UnpackAsync(type);

            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
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