using System;
using System.IO;
using TestModels;
using Xunit;

namespace Zaabee.ZeroFormatter.UnitTest
{
    public partial class ZeroFormatterUnitTest
    {
        [Fact]
        public void StreamTest()
        {
            var testModel = TestModelFactory.Create();

            var stream1 = testModel.ToStream();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(testModel);

            var unPackResult1 = stream1.FromStream<TestModel>();
            var unPackResult2 = stream2.FromStream<TestModel>();
            var unPackResult3 = stream3.FromStream<TestModel>();

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
            
            Assert.Equal(0,ZeroFormatterHelper.ToStream<TestModel>(null).Length);
            Assert.Null(ZeroFormatterHelper.FromStream<TestModel>(null));
            var ms = new MemoryStream();
            ZeroFormatterHelper.Pack<TestModel>(null, ms);
            Assert.Equal(0,ms.Length);
            Assert.Equal(0,ms.Position);
        }
    }
}