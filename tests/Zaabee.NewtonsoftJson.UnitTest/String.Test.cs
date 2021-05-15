using System;
using TestModels;
using Xunit;

namespace Zaabee.NewtonsoftJson.UnitTest
{
    public partial class NewtonsoftJsonUnitTest
    {
        [Fact]
        public void StringTest()
        {
            TestModel nullModel = null;
            var emptyJson = nullModel.ToJson();
            nullModel = emptyJson.FromJson<TestModel>();
            Assert.Null(nullModel);
            
            var testModel = TestModelFactory.Create();
            var json = testModel.ToJson();
            var result = json.FromJson<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}