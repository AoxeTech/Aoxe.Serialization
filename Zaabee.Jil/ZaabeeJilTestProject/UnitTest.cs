using System;
using System.IO;
using Jil;
using Xunit;
using Zaabee.Jil;

namespace ZaabeeJilTestProject
{
    public class UnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var testModel = GetTestModel();
            var bytes = testModel.ToBytes();
            var result = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void StreamTest()
        {
            var testModel = GetTestModel();

            var stream1 = testModel.Pack();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.Pack(testModel);

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
            object testModel = GetTestModel();
            var bytes = testModel.ToBytes();
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
            object testModel = GetTestModel();

            var stream1 = testModel.Pack();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.Pack(testModel);

            var unPackResult1 = (TestModel) stream1.Unpack(type);
            var unPackResult2 = (TestModel) stream2.Unpack(type);
            var unPackResult3 = (TestModel) stream3.Unpack(type);

            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age, ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age, ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age, ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));
        }

        [Fact]
        public void StringNonGenericTest()
        {
            object testModel = GetTestModel();
            var json = testModel.ToJson();
            var result = (TestModel) json.FromJson(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age, ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
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
        public void ToJson()
        {
            var testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = DateTimeOffset.Now,
                Name = "banana"
            };

            var jsonStr = testModel.ToJson();
            var result1 = jsonStr.FromJson<TestModel>();
            var result2 = jsonStr.FromJson(typeof(TestModel)) as TestModel;

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

            Assert.Equal(testModel.Id, result2.Id);
            Assert.Equal(testModel.Age, result2.Age);
            Assert.Equal(testModel.CreateTime.Year, result2.CreateTime.Year);
            Assert.Equal(testModel.CreateTime.Month, result2.CreateTime.Month);
            Assert.Equal(testModel.CreateTime.Day, result2.CreateTime.Day);
            Assert.Equal(testModel.CreateTime.Hour, result2.CreateTime.Hour);
            Assert.Equal(testModel.CreateTime.Minute, result2.CreateTime.Minute);
            Assert.Equal(testModel.CreateTime.Second, result2.CreateTime.Second);
            Assert.Equal(testModel.CreateTime.Millisecond, result2.CreateTime.Millisecond);
            Assert.Equal(testModel.Name, result2.Name);
        }

        [Fact]
        public void ToJsonWithOptions()
        {
            var testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = DateTimeOffset.Now,
                Name = "banana"
            };

            var options = new Options(dateFormat: DateTimeFormat.ISO8601,
                excludeNulls: true, includeInherited: true,
                serializationNameFormat: SerializationNameFormat.CamelCase);

            var jsonStr = testModel.ToJson(options);
            var result1 = jsonStr.FromJson<TestModel>(options);
            var result2 = jsonStr.FromJson(typeof(TestModel), options) as TestModel;

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

            Assert.Equal(testModel.Id, result2.Id);
            Assert.Equal(testModel.Age, result2.Age);
            Assert.Equal(testModel.CreateTime.Year, result2.CreateTime.Year);
            Assert.Equal(testModel.CreateTime.Month, result2.CreateTime.Month);
            Assert.Equal(testModel.CreateTime.Day, result2.CreateTime.Day);
            Assert.Equal(testModel.CreateTime.Hour, result2.CreateTime.Hour);
            Assert.Equal(testModel.CreateTime.Minute, result2.CreateTime.Minute);
            Assert.Equal(testModel.CreateTime.Second, result2.CreateTime.Second);
            Assert.Equal(testModel.CreateTime.Millisecond, result2.CreateTime.Millisecond);
            Assert.Equal(testModel.Name, result2.Name);
        }
    }
}