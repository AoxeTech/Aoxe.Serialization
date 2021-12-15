using System;
using TestModels;
using Xunit;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson.UnitTest
{
    public partial class NewtonsoftJsonUnitTest
    {
        [Fact]
        public void BytesTest()
        {
            TestModel? nullModel = null;
            var emptyBytes = nullModel.ToBytes();
            nullModel = emptyBytes.FromBytes<TestModel>();
            Assert.Null(nullModel);

            var testModel = TestModelFactory.Create();
            var bytes0 = testModel.ToBytes();
            var result0 = bytes0.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));
        }
    }
}