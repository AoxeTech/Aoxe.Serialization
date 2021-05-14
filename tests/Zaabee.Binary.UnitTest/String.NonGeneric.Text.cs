using System;
using TestModels;
using Xunit;

namespace Zaabee.Binary.UnitTest
{
    public partial class BinaryUnitTest
    {
        [Fact]
        public void TextNonGenericTest()
        {
            var testModel = TestModelFactory.Create();
            var base64 = testModel.ToBase64();
            var result = (TestModel) base64.FromBase64();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}