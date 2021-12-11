using System;
using System.IO;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.Utf8Json.UnitTest
{
    public partial class Utf8JsonUnitTest
    {
        [Fact]
        public void StreamNonGenericTest()
        {
            var type = typeof(TestModel);

            object nullModel = null;
            Stream nullMs = null;
            nullModel.PackTo(nullMs);
            nullMs.PackBy(nullModel);
            nullModel.PackTo(type, nullMs);
            nullMs.PackBy(type, nullModel);
            var emptyStream = nullModel.ToStream();
            Assert.True(emptyStream.IsNullOrEmpty());
            nullModel = emptyStream.FromStream<object>();
            Assert.Null(nullModel);

            object testModel = TestModelFactory.Create();

            var stream1 = testModel.ToStream(type);
            var stream2 = new MemoryStream();
            testModel.PackTo(type, stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(type, testModel);

            var unPackResult1 = (TestModel) stream1.FromStream(type);
            var unPackResult2 = (TestModel) stream2.FromStream(type);
            var unPackResult3 = (TestModel) stream3.FromStream(type);

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
        
        [Fact]
        public void StreamNonGenericWithTypeTest()
        {
            var type = typeof(TestModel);
            object testModel = TestModelFactory.Create();

            var stream1 = testModel.ToStream();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(testModel);

            var unPackResult1 = (TestModel) stream1.FromStream(type);
            var unPackResult2 = (TestModel) stream2.FromStream(type);
            var unPackResult3 = (TestModel) stream3.FromStream(type);

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