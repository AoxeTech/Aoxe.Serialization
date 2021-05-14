using System;
using System.IO;
using System.Threading.Tasks;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.Jil.UnitTest
{
    public partial class JilUnitTest
    {
        [Fact]
        public async Task StreamNonGenericTestAsync()
        {
            var type = typeof(TestModel);
            object testModel = TestModelFactory.Create();

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
    }
}