using System;
using TestModels;
using Xunit;

namespace Zaabee.SystemTextJson.UnitTest
{
    public partial class SystemTextJsonUnitTest
    {
        [Fact]
        public void ReadOnlySpanBytesNonGenericTest()
        {
            object testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes(typeof(TestModel));
            var result = (TestModel) ((ReadOnlySpan<byte>) bytes).FromBytes(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}