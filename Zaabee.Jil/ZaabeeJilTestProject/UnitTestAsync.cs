using System;
using System.IO;
using System.Threading.Tasks;
using Jil;
using Xunit;
using Zaabee.Jil;

namespace ZaabeeJilTestProject
{
    public class UnitTestAsync
    {
        [Fact]
        public async Task BytesTestAsync()
        {
            var testModel = GetTestModel();
            var bytes = await testModel.ToBytesAsync();
            var result = await bytes.FromBytesAsync<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public async Task StreamTestAsync()
        {
            var testModel = GetTestModel();

            var stream1 = await testModel.PackAsync();
            var stream2 = new MemoryStream();
            await testModel.PackToAsync(stream2);
            var stream3 = new MemoryStream();
            await stream3.PackByAsync(testModel);

            var unPackResult1 = await stream1.UnpackAsync<TestModel>();
            var unPackResult2 = await stream2.UnpackAsync<TestModel>();
            var unPackResult3 = await stream3.UnpackAsync<TestModel>();

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
        public async Task StringTestAsync()
        {
            var testModel = GetTestModel();
            var json = await testModel.ToJsonAsync();
            var result = await json.FromJsonAsync<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public async Task BytesNonGenericTestAsync()
        {
            object testModel = GetTestModel();
            var bytes = await testModel.ToBytesAsync();
            var result = (TestModel) await bytes.FromBytesAsync(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public async Task StreamNonGenericTestAsync()
        {
            var type = typeof(TestModel);
            object testModel = GetTestModel();

            var stream1 = await testModel.PackAsync();
            var stream2 = new MemoryStream();
            await testModel.PackToAsync(stream2);
            var stream3 = new MemoryStream();
            await stream3.PackByAsync(testModel);

            var unPackResult1 = (TestModel) await stream1.UnpackAsync(type);
            var unPackResult2 = (TestModel) await stream2.UnpackAsync(type);
            var unPackResult3 = (TestModel) await stream3.UnpackAsync(type);

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
        public async Task StringNonGenericTestAsync()
        {
            object testModel = GetTestModel();
            var json = await testModel.ToJsonAsync();
            var result = (TestModel) await json.FromJsonAsync(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
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
        public async Task ToJsonAsync()
        {
            var testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = DateTimeOffset.Now,
                Name = "banana"
            };

            var jsonStr = await testModel.ToJsonAsync();
            var result1 = await jsonStr.FromJsonAsync<TestModel>();
            var result2 = await jsonStr.FromJsonAsync(typeof(TestModel)) as TestModel;

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
        public async Task ToJsonWithOptionsAsync()
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

            var jsonStr = await testModel.ToJsonAsync(options);
            var result1 = await jsonStr.FromJsonAsync<TestModel>(options);
            var result2 = await jsonStr.FromJsonAsync(typeof(TestModel), options) as TestModel;

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