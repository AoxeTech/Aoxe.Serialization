using System;
using System.IO;
using TestModels;
using Xunit;

namespace Zaabee.MessagePack.UnitTest
{
    public partial class MsgPackUnitTest
    {
        [Fact]
        public void StreamTest()
        {
            var testModel = TestModelFactory.Create();
            var type = typeof(TestModel);

            var stream1 = testModel.ToStream();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(testModel);

            var stream4 = testModel.ToStream(type);
            var stream5 = new MemoryStream();
            testModel.PackTo(type, stream5);
            var stream6 = new MemoryStream();
            stream6.PackBy(type, testModel);

            var unPackResult1 = stream1.Unpack<TestModel>();
            var unPackResult2 = stream2.Unpack<TestModel>();
            var unPackResult3 = stream3.Unpack<TestModel>();

            var unPackResult4 = (TestModel)stream4.Unpack(type);
            var unPackResult5 = (TestModel)stream5.Unpack(type);
            var unPackResult6 = (TestModel)stream6.Unpack(type);

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
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult6.Id, unPackResult6.Age, unPackResult6.CreateTime, unPackResult6.Name,
                    unPackResult6.Gender));

            TestModel nullModel = null;
            Stream nullMs = null;
            nullModel.PackTo(nullMs);
        }
    }
}