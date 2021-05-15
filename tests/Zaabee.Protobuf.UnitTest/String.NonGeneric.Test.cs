using System;
using TestModels;
using Xunit;

namespace Zaabee.Protobuf.UnitTest
{
    public partial class ProtobufUnitTest
    {
        [Fact]
        public void StringNonGenericTest()
        {
            var type = typeof(TestModel);
            object testModel = TestModelFactory.Create();
            var text = testModel.ToBase64();
            var result = (TestModel) text.FromBase64(type);
            Assert.Equal(Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}