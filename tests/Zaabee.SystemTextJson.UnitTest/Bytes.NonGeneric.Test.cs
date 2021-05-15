using System;
using TestModels;
using Xunit;

namespace Zaabee.SystemTextJson.UnitTest
{
    public partial class SystemTextJsonUnitTest
    {
        [Fact]
        public void BytesNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes(type);
            var result = (TestModel) bytes.FromBytes(type);
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}