using System;
using TestModels;
using Xunit;

namespace Zaabee.MsgPack.UnitTest
{
    public partial class MsgPackUnitTest
    {
        [Fact]
        public void StringNonGenericTest()
        {
            var testModel = TestModelFactory.Create();
            var base64 = testModel.ToBase64(typeof(TestModel));
            var result = (TestModel) base64.FromBase64(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}