using System;
using System.IO;
using System.Threading.Tasks;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.Utf8Json.UnitTest
{
    public partial class Utf8JsonUnitTest
    {
        [Fact]
        public async Task StreamNonGenericAsyncTest()
        {
            var type = typeof(TestModel);

            object nullModel = null;
            MemoryStream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            await nullMs.PackByAsync(nullModel);
            await nullModel.PackToAsync(type, nullMs);
            await nullMs.PackByAsync(type, nullModel);
            var emptyStream = await nullModel.ToStreamAsync();
            Assert.True(emptyStream.IsNullOrEmpty());
            nullModel = await emptyStream.UnpackAsync<object>();
            Assert.Null(nullModel);

            object testModel = TestModelFactory.Create();

            var stream0 = new FileStream(".\\StreamNonGenericTest0", FileMode.Create);
            await testModel.PackToAsync(type, stream0);
            var stream1 = await testModel.ToStreamAsync();
            var stream2 = await testModel.ToStreamAsync(typeof(TestModel));
            var stream3 = new MemoryStream();
            await testModel.PackToAsync(stream3);

            var unPackResult0 = (TestModel) await stream0.UnpackAsync(type);
            var unPackResult1 = (TestModel) await stream1.UnpackAsync(type);
            var unPackResult2 = (TestModel) await stream2.UnpackAsync(type);
            var unPackResult3 = (TestModel) await stream3.UnpackAsync(type);

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
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));
        }
    }
}