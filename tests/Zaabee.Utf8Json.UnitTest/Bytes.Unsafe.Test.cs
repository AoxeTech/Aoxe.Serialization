using System;
using System.Linq;
using TestModels;
using Xunit;

namespace Zaabee.Utf8Json.UnitTest
{
    public partial class Utf8JsonUnitTest
    {
        [Fact]
        public void BytesUnsafeTest()
        {
            var testModel = TestModelFactory.Create();
            var arraySegmentBytes = testModel.ToBytesUnsafe();
            var bytes = arraySegmentBytes.Take(arraySegmentBytes.Count).ToArray();
            var result = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}