using System;
using TestModels;
using Xunit;

namespace Zaabee.ZeroFormatter.UnitTest
{
    public partial class ZeroFormatterUnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes();
            var result = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
            
            Assert.Empty(ZeroFormatterHelper.ToBytes(typeof(TestModel),null));
            Assert.Null(ZeroFormatterHelper.FromBytes<TestModel>(null));
        }
    }
}