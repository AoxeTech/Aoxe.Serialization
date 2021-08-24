using System;
using System.IO;
using System.Threading.Tasks;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.MessagePack.UnitTest
{
    public partial class MsgPackUnitTest
    {
        [Fact]
        public async Task StreamAsyncTest()
        {
            var testModel = TestModelFactory.Create();
            var type = typeof(TestModel);

            var stream0 = new FileStream(".\\StreamTest0", FileMode.Create);
            await testModel.PackToAsync(stream0);
            var stream1 = new FileStream(".\\StreamTest1", FileMode.Create);
            await stream1.PackByAsync(testModel);

            var stream2 = new FileStream(".\\StreamTest2", FileMode.Create);
            await testModel.PackToAsync(type, stream2);
            var stream3 = new FileStream(".\\StreamTest3", FileMode.Create);
            await stream3.PackByAsync(type, testModel);

            var stream4 = await testModel.ToStreamAsync();
            var stream5 = await testModel.ToStreamAsync(type);

            var unPackResult0 = await stream0.UnpackAsync<TestModel>();
            var unPackResult1 = await stream1.UnpackAsync<TestModel>();

            var unPackResult2 = (TestModel)await stream2.UnpackAsync(type);
            var unPackResult3 = (TestModel)await stream3.UnpackAsync(type);

            var unPackResult4 = await stream4.UnpackAsync<TestModel>();
            var unPackResult5 = (TestModel)await stream5.UnpackAsync(type);

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
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult4.Id, unPackResult4.Age, unPackResult4.CreateTime, unPackResult4.Name,
                    unPackResult4.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult5.Id, unPackResult5.Age, unPackResult5.CreateTime, unPackResult5.Name,
                    unPackResult5.Gender));

            object nullModel = null;
            MemoryStream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            Assert.True((await nullModel.ToStreamAsync()).ToArray().IsNullOrEmpty());
        }
    }
}