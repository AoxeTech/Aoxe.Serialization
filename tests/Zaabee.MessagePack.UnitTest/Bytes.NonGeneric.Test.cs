using System;
using TestModels;
using Xunit;

namespace Zaabee.MessagePack.UnitTest
{
    public partial class MsgPackUnitTest
    {
        [Fact]
        public void BytesNonGenericTest()
        {
            var testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes(typeof(TestModel));
            var result = (TestModel) bytes.FromBytes(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}