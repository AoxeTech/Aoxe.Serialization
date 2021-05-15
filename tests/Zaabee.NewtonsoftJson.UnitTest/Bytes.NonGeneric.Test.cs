using System;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson.UnitTest
{
    public partial class NewtonsoftJsonUnitTest
    {
        [Fact]
        public void BytesNonGenericTest()
        {
            object nullModel = null;
            var emptyBytes = nullModel.ToBytes();
            Assert.True(emptyBytes.IsNullOrEmpty());
            nullModel = emptyBytes.FromBytes<object>();
            Assert.Null(nullModel);

            object testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes(typeof(TestModel));
            var result = (TestModel) bytes.FromBytes(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}