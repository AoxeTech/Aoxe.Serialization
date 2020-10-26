using System;
using System.IO;
using System.Text;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void DefaultTest()
        {
            NewtonsoftJsonHelper.DefaultEncoding = Encoding.UTF8;
            NewtonsoftJsonHelper.DefaultSettings = null;
            Assert.Equal(NewtonsoftJsonHelper.DefaultEncoding, Encoding.UTF8);
            Assert.Null(NewtonsoftJsonHelper.DefaultSettings);
        }

        [Fact]
        public void BytesTest()
        {
            TestModel nullModel = null;
            var emptyBytes = nullModel.ToBytes();
            Assert.True(emptyBytes.IsNullOrEmpty());
            nullModel = emptyBytes.FromBytes<TestModel>();
            Assert.Null(nullModel);

            var testModel = GetTestModel();
            var bytes0 = testModel.ToBytes();
            var result0 = bytes0.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));
        }

        [Fact]
        public void StreamTest()
        {
            TestModel nullModel = null;
            MemoryStream nullMs = null;
            nullModel.PackTo(nullMs);
            nullMs.PackBy(nullModel);
            var emptyStream = nullModel.ToStream();
            Assert.True(emptyStream.IsNullOrEmpty());
            nullModel = emptyStream.Unpack<TestModel>();
            Assert.Null(nullModel);

            var testModel = GetTestModel();
            var stream1 = testModel.ToStream();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(testModel);

            var unPackResult1 = stream1.Unpack<TestModel>();
            var unPackResult2 = stream2.Unpack<TestModel>();
            var unPackResult3 = stream3.Unpack<TestModel>();

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
        }

        [Fact]
        public void StringTest()
        {
            TestModel nullModel = null;
            var emptyJson = nullModel.ToJson();
            nullModel = emptyJson.FromJson<TestModel>();
            Assert.Null(nullModel);
            
            var testModel = GetTestModel();
            var json = testModel.ToJson();
            var result = json.FromJson<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void BytesNonGenericTest()
        {
            object nullModel = null;
            var emptyBytes = nullModel.ToBytes();
            Assert.True(emptyBytes.IsNullOrEmpty());
            nullModel = emptyBytes.FromBytes<object>();
            Assert.Null(nullModel);

            object testModel = GetTestModel();
            var bytes = testModel.ToBytes(typeof(TestModel));
            var result = (TestModel) bytes.FromBytes(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void StreamNonGenericTest()
        {
            var type = typeof(TestModel);

            object nullModel = null;
            MemoryStream nullMs = null;
            nullModel.PackTo(nullMs);
            nullMs.PackBy(nullModel);
            nullModel.PackTo(type, nullMs);
            nullMs.PackBy(type, nullModel);
            var emptyStream = nullModel.ToStream();
            Assert.True(emptyStream.IsNullOrEmpty());
            nullModel = emptyStream.Unpack<object>();
            Assert.Null(nullModel);
            
            object testModel = GetTestModel();

            var stream1 = testModel.ToStream(type);
            var stream2 = new MemoryStream();
            testModel.PackTo(type, stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(type, testModel);

            var unPackResult1 = (TestModel) stream1.Unpack(type);
            var unPackResult2 = (TestModel) stream2.Unpack(type);
            var unPackResult3 = (TestModel) stream3.Unpack(type);

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
        public void StringNonGenericTest()
        {
            object nullModel = null;
            var emptyJson = nullModel.ToJson();
            nullModel = emptyJson.FromJson<TestModel>();
            Assert.Null(nullModel);
            
            var type = typeof(TestModel);
            object testModel = GetTestModel();
            var json0 = testModel.ToJson(type);
            var result0 = json0.FromJson(type);
            var json1 = testModel.ToJson(type);
            var result1 = json1.FromJson(type);
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(((TestModel) result0).Id, ((TestModel) result0).Age, ((TestModel) result0).CreateTime,
                    ((TestModel) result0).Name, ((TestModel) result0).Gender));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(((TestModel) result1).Id, ((TestModel) result1).Age, ((TestModel) result1).CreateTime,
                    ((TestModel) result1).Name, ((TestModel) result1).Gender));
        }

        private static TestModel GetTestModel()
        {
            return new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1).ToUniversalTime(),
                Name = "apple",
                Gender = Gender.Female
            };
        }

        [Fact]
        public void ObjectString()
        {
            var testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = DateTime.Now,
                Name = "banana"
            };

            var jsonStr = testModel.ToJson();
            var result1 = jsonStr.FromJson<TestModel>();

            Assert.Equal(testModel.Id, result1.Id);
            Assert.Equal(testModel.Age, result1.Age);
            Assert.Equal(testModel.CreateTime.Year, result1.CreateTime.Year);
            Assert.Equal(testModel.CreateTime.Month, result1.CreateTime.Month);
            Assert.Equal(testModel.CreateTime.Day, result1.CreateTime.Day);
            Assert.Equal(testModel.CreateTime.Hour, result1.CreateTime.Hour);
            Assert.Equal(testModel.CreateTime.Minute, result1.CreateTime.Minute);
            Assert.Equal(testModel.CreateTime.Second, result1.CreateTime.Second);
            Assert.Equal(testModel.CreateTime.Millisecond, result1.CreateTime.Millisecond);
            Assert.Equal(testModel.Name, result1.Name);
        }

        [Fact]
        public void ObjectBytes()
        {
            var testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = DateTime.Now,
                Name = "banana"
            };

            var bytes = testModel.ToBytes();
            var result1 = bytes.FromBytes<TestModel>();

            Assert.Equal(testModel.Id, result1.Id);
            Assert.Equal(testModel.Age, result1.Age);
            Assert.Equal(testModel.CreateTime.Year, result1.CreateTime.Year);
            Assert.Equal(testModel.CreateTime.Month, result1.CreateTime.Month);
            Assert.Equal(testModel.CreateTime.Day, result1.CreateTime.Day);
            Assert.Equal(testModel.CreateTime.Hour, result1.CreateTime.Hour);
            Assert.Equal(testModel.CreateTime.Minute, result1.CreateTime.Minute);
            Assert.Equal(testModel.CreateTime.Second, result1.CreateTime.Second);
            Assert.Equal(testModel.CreateTime.Millisecond, result1.CreateTime.Millisecond);
            Assert.Equal(testModel.Name, result1.Name);
        }
    }
}