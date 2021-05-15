using System;
using TestModels;
using Xunit;

namespace Zaabee.ZeroFormatter.UnitTest
{
    public partial class ZeroFormatterUnitTest
    {
        [Fact]
        public void StringNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = TestModelFactory.Create();
            var base64 = testModel.ToBase64(type);
            var result = (TestModel) base64.FromBase64(type);
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}