using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Zaabee.Jil;

namespace ZaabeeJilTestProject
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

            var unPackResult0 = stream0.Unpack<TestModel>();
            var unPackResult1 = stream1.Unpack<TestModel>();

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
        public async Task StreamNonGenericTestAsync()
        {
            var type = typeof(TestModel);
            object testModel = GetTestModel();

            var stream0 = new FileStream(".\\StreamNonGenericTestAsync0", FileMode.Create);
            await testModel.PackToAsync(stream0);
            var stream1 = new FileStream(".\\StreamNonGenericTestAsync1", FileMode.Create);
            await stream1.PackByAsync(testModel);

            var unPackResult0 = (TestModel) stream0.Unpack(type);
            var unPackResult1 = (TestModel) stream1.Unpack(type);

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