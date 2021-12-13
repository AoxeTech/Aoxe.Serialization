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
        public async Task StreamAsyncTest()
        {
            TestModel nullModel = null;
            Stream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            await nullMs.PackByAsync(nullModel);
            Assert.Null(nullModel);
            
            var testModel = TestModelFactory.Create();

            var stream1 = new FileStream(".\\StreamTest1", FileMode.Create);
            await testModel.PackToAsync(stream1);
            var stream2 = new MemoryStream();
            await stream2.PackByAsync(testModel);

            var unPackResult1 = await stream1.FromStreamAsync<TestModel>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
        }
    }
}