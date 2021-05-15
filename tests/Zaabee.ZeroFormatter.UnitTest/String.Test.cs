using System;
using TestModels;
using Xunit;

namespace Zaabee.ZeroFormatter.UnitTest
{
    public partial class ZeroFormatterUnitTest
    {
        [Fact]
        public void StringTest()
        {
            var testModel = TestModelFactory.Create();
            var base64 = testModel.ToBase64();
            var result = base64.FromBase64<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
            
            Assert.Empty(ZeroFormatterHelper.Serialize(typeof(TestModel),null));
            Assert.Null(ZeroFormatterHelper.Deserialize<TestModel>(null));
        }

    }
}