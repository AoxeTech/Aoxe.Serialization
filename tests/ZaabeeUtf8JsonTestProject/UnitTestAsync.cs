using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Zaabee.Utf8Json;

namespace ZaabeeUtf8JsonTestProject
{
    public class UnitTestAsync
    {

        [Fact]
        public async Task StreamTest()
        {
            var testModel = GetTestModel();
            var stream0 = new FileStream(".\\StreamTest0",FileMode.Create);
            await testModel.PackToAsync(stream0);
            var stream1 = new FileStream(".\\StreamTest1",FileMode.Create);
            await stream1.PackByAsync(testModel);

            var unPackResult0 = await stream0.UnpackAsync<TestModel>();
            var unPackResult1 = await stream1.UnpackAsync<TestModel>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult0.Id, unPackResult0.Age, unPackResult0.CreateTime, unPackResult0.Name,
                    unPackResult0.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
        }

        [Fact]
        public async Task StreamNonGenericTest()
        {
            var type = typeof(TestModel);
            object testModel = GetTestModel();

            var stream0 = new FileStream(".\\StreamNonGenericTest0",FileMode.Create);
            await testModel.PackToAsync(type, stream0);
            var stream1 = new FileStream(".\\StreamNonGenericTest1",FileMode.Create);
            await stream1.PackByAsync(type, testModel);

            var unPackResult0 = (TestModel) await stream0.UnpackAsync(type);
            var unPackResult1 = (TestModel) await stream1.UnpackAsync(type);

            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult0.Id, unPackResult0.Age, unPackResult0.CreateTime, unPackResult0.Name,
                    unPackResult0.Gender));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
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