using System;
using TestModels;
using Xunit;

namespace Zaabee.Jil.UnitTest
{
    public partial class JilUnitTest
    {
        [Fact]
        public void StringNonGenericTest()
        {
            object testModel = TestModelFactory.Create();
            var json = testModel.ToJson();
            var result = (TestModel) json.FromJson(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age, ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}