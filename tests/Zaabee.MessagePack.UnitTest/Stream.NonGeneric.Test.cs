using System;
using System.IO;
using TestModels;
using Xunit;

namespace Zaabee.MessagePack.UnitTest
{
    public partial class MsgPackUnitTest
    {
        [Fact]
        public void StreamNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = TestModelFactory.Create();

            var stream1 = testModel.ToStream(type);
            var stream2 = new MemoryStream();
            testModel.PackTo(type, stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(type, testModel);

            var unPackResult1 = (TestModel) stream1.FromStream(type);
            var unPackResult2 = (TestModel) stream2.FromStream(type);
            var unPackResult3 = (TestModel) stream3.FromStream(type);

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

            TestModel nullModel = null;
            Stream nullMs = null;
            nullModel.PackTo(typeof(TestModel), nullMs);
        }
    }
}