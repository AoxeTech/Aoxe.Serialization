using System;
using System.IO;
using System.Threading.Tasks;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson.UnitTest
{
    public partial class SystemTextJsonUnitTest
    {
        [Fact]
        public async Task StreamNonGenericAsyncTest()
        {
            var type = typeof(TestModel);

            object nullModel = null;
            Stream nullMs = null;
            await nullModel.PackToAsync(type, nullMs);
            await nullMs.PackByAsync(type, nullModel);
            Assert.Null(nullModel);
            
            object testModel = TestModelFactory.Create();

            var stream1 = new FileStream(".\\StreamNonGenericTest1", FileMode.Create);
            await testModel.PackToAsync(type, stream1);
            var stream2 = new MemoryStream();
            await stream2.PackByAsync(type, testModel);

            var unPackResult1 = (TestModel) await stream1.FromStreamAsync(type);

            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
        }
    }
}