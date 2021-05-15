using System;
using TestModels;
using Xunit;

namespace Zaabee.Utf8Json.UnitTest
{
    public partial class Utf8JsonUnitTest
    {
        [Fact]
        public void StringNonGenericTest()
        {
            object testModel = TestModelFactory.Create();
            var json1 = testModel.ToJson();
            var result1 = json1.FromJson(typeof(TestModel));
            var json2 = testModel.ToJson(typeof(TestModel));
            var result2 = json2.FromJson(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(((TestModel) result1).Id, ((TestModel) result1).Age, ((TestModel) result1).CreateTime,
                    ((TestModel) result1).Name, ((TestModel) result1).Gender));
        }
    }
}