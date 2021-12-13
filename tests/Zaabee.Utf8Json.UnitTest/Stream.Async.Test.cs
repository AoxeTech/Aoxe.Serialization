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
        public async Task StreamAsyncTest()
        {
            TestModel nullModel = null;
            Stream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            await nullMs.PackByAsync(nullModel);
            Assert.Null(nullModel);
            
            var testModel = TestModelFactory.Create();
            var stream0 = new FileStream(".\\StreamTest0",FileMode.Create);
            await testModel.PackToAsync(stream0);

            var unPackResult0 = await stream0.FromStreamAsync<TestModel>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult0.Id, unPackResult0.Age, unPackResult0.CreateTime, unPackResult0.Name,
                    unPackResult0.Gender));
        }
    }
}