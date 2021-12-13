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

            var unPackResult0 = await stream0.FromStreamAsync<TestModel>();
            var unPackResult1 = await stream1.FromStreamAsync<TestModel>();

            var unPackResult2 = (TestModel)await stream2.FromStreamAsync(type);
            var unPackResult3 = (TestModel)await stream3.FromStreamAsync(type);

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

            object nullModel = null;
            Stream nullMs = null;
            await nullModel.PackToAsync(nullMs);
            Assert.True(nullModel.ToStream().IsNullOrEmpty());
        }
    }
}