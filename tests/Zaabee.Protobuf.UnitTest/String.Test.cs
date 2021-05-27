using System;
using TestModels;
using Xunit;

namespace Zaabee.Protobuf.UnitTest
{
    public partial class ProtobufUnitTest
    {
        [Fact]
        public void StringTest()
        {
            var testModel = TestModelFactory.Create();
            var text = testModel.SerializeToBase64();
            var result = text.DeserializeFromBase64<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}