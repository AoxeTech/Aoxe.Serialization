using System;
using Xunit;
using Zaabee.Binary.UnitTest.Models;

namespace Zaabee.Binary.UnitTest
{
    public partial class BinaryUnitTest
    {
        [Fact]
        public void BytesNonGenericTest()
        {
            var testModel = GetTestModel();
            var bytes = testModel.ToBytes();
            var result = (TestModel) bytes.FromBytes();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}