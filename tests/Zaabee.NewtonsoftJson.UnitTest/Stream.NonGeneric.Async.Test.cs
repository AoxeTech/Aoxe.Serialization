using System;
using System.IO;
using System.Threading.Tasks;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson.UnitTest
{
    public partial class NewtonsoftJsonUnitTest
    {
        [Fact]
        public async Task StreamNonGenericAsyncTest()
        {
            var type = typeof(TestModel);

            object nullModel = null;
            Stream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            await nullMs.PackByAsync(nullModel);
            await nullModel.PackToAsync(type, nullMs);
            await nullMs.PackByAsync(type, nullModel);
            Assert.Null(nullModel);

            object testModel = TestModelFactory.Create();

            var stream0 = new FileStream(".\\StreamNonGenericTest0", FileMode.Create);
            await testModel.PackToAsync(type, stream0);
            var stream1 = new FileStream(".\\StreamNonGenericTest1", FileMode.Create);
            await stream1.PackByAsync(type, testModel);

            var unPackResult0 = (TestModel) await stream0.FromStreamAsync(type);
            var unPackResult1 = (TestModel) await stream1.FromStreamAsync(type);

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
    }
}