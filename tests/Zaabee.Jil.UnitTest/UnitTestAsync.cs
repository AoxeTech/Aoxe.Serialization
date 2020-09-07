using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Zaabee.Extensions;
using Zaabee.Jil;

namespace Zaabee.Jil.UnitTest
{
    public class UnitTestAsync
    {
        [Fact]
        public async Task StreamTestAsync()
        {
            var testModel = GetTestModel();

            var stream0 = new FileStream(".\\StreamTestAsync0", FileMode.Create);
            await testModel.PackToAsync(stream0);
            var stream1 = new FileStream(".\\StreamTestAsync1", FileMode.Create);
            await stream1.PackByAsync(testModel);
            var stream2 = await testModel.ToStreamAsync();

            var unPackResult0 = await stream0.UnpackAsync<TestModel>();
            var unPackResult1 = await stream1.UnpackAsync<TestModel>();
            var unPackResult2 = await stream2.UnpackAsync<TestModel>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult0.Id, unPackResult0.Age, unPackResult0.CreateTime, unPackResult0.Name,
                    unPackResult0.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));

            TestModel nullModel = null;
            MemoryStream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            Assert.True((await nullModel.ToStreamAsync()).ToArray().IsNullOrEmpty());
        }

        [Fact]
        public async Task StreamNonGenericTestAsync()
        {
            var type = typeof(TestModel);
            object testModel = GetTestModel();

            var stream0 = new FileStream(".\\StreamNonGenericTestAsync0", FileMode.Create);
            await testModel.PackToAsync(stream0);
            var stream1 = new FileStream(".\\StreamNonGenericTestAsync1", FileMode.Create);
            await stream1.PackByAsync(testModel);
            var stream2 = await testModel.ToStreamAsync();

            var unPackResult0 = (TestModel) await stream0.UnpackAsync(type);
            var unPackResult1 = (TestModel) await stream1.UnpackAsync(type);
            var unPackResult2 = (TestModel) await stream2.UnpackAsync(type);

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
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));

            object nullModel = null;
            MemoryStream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            Assert.True((await nullModel.ToStreamAsync()).ToArray().IsNullOrEmpty());
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