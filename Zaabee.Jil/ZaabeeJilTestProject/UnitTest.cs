using System;
using Jil;
using Xunit;
using Zaabee.Jil;

namespace ZaabeeJilTestProject
{
    public class UnitTest
    {
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

            var jsonStr = testModel.ToJil();
            var result1 = jsonStr.FromJil<TestModel>();
            var result2 = jsonStr.FromJil(typeof(TestModel)) as TestModel;

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

            var jsonStr = testModel.ToJil(options);
            var result1 = jsonStr.FromJil<TestModel>(options);
            var result2 = jsonStr.FromJil(typeof(TestModel), options) as TestModel;

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