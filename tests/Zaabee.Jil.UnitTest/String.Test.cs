using System;
using Jil;
using TestModels;
using Xunit;

namespace Zaabee.Jil.UnitTest
{
    public partial class JilUnitTest
    {
        [Fact]
        public void StringTest()
        {
            var testModel = TestModelFactory.Create();
            var json = testModel.ToJson();
            var result = json.FromJson<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void ToJson()
        {
            var testModel = TestModelFactory.Create();

            var jsonStr = testModel.ToJson();
            var result1 = jsonStr.FromJson<TestModel>();
            var result2 = jsonStr.FromJson(typeof(TestModel)) as TestModel;

            Assert.Equal(testModel.Id, result1.Id);
            Assert.Equal(testModel.Age, result1.Age);
            Assert.Equal(testModel.CreateTime, result1.CreateTime);
            Assert.Equal(testModel.Name, result1.Name);

            Assert.Equal(testModel.Id, result2.Id);
            Assert.Equal(testModel.Age, result2.Age);
            Assert.Equal(testModel.CreateTime, result2.CreateTime);
            Assert.Equal(testModel.Name, result2.Name);
        }

        [Fact]
        public void ToJsonWithOptions()
        {
            var testModel = TestModelFactory.Create();

            var options = new Options(dateFormat: DateTimeFormat.ISO8601,
                excludeNulls: true, includeInherited: true,
                serializationNameFormat: SerializationNameFormat.CamelCase);

            var jsonStr = testModel.ToJson(options);
            var result1 = jsonStr.FromJson<TestModel>(options);
            var result2 = jsonStr.FromJson(typeof(TestModel), options) as TestModel;

            Assert.Equal(testModel.Id, result1.Id);
            Assert.Equal(testModel.Age, result1.Age);
            Assert.Equal(testModel.CreateTime, result1.CreateTime);
            Assert.Equal(testModel.Name, result1.Name);

            Assert.Equal(testModel.Id, result2.Id);
            Assert.Equal(testModel.Age, result2.Age);
            Assert.Equal(testModel.CreateTime, result2.CreateTime);
            Assert.Equal(testModel.Name, result2.Name);
        }
    }
}