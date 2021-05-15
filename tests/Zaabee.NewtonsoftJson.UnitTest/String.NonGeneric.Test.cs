using System;
using TestModels;
using Xunit;

namespace Zaabee.NewtonsoftJson.UnitTest
{
    public partial class NewtonsoftJsonUnitTest
    {
        [Fact]
        public void StringNonGenericTest()
        {
            object nullModel = null;
            var emptyJson = nullModel.ToJson();
            nullModel = emptyJson.FromJson<TestModel>();
            Assert.Null(nullModel);
            
            var type = typeof(TestModel);
            object testModel = TestModelFactory.Create();
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
    }
}