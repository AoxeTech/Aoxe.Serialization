using System;
using Xunit;

namespace Zaabee.Binary.UnitTest
{
    public partial class BinaryUnitTest
    {
        [Fact]
        public void TextTest()
        {
            var testModel = GetTestModel();
            var base64 = testModel.ToBase64();
            var result = base64.FromBase64<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}