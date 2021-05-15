using System;
using System.Linq;
using TestModels;
using Xunit;

namespace Zaabee.Utf8Json.UnitTest
{
    public partial class Utf8JsonUnitTest
    {
        [Fact]
        public void BytesUnsafeNonGenericTest()
        {
            object testModel = TestModelFactory.Create();
            var arraySegmentBytes = testModel.ToBytesUnsafe();
            var bytes = arraySegmentBytes.Take(arraySegmentBytes.Count).ToArray();
            var result = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void BytesUnsafeNonGenericWithTypeTest()
        {
            var type = typeof(TestModel);
            object testModel = TestModelFactory.Create();
            var arraySegmentBytes = testModel.ToBytesUnsafe(type);
            var bytes = arraySegmentBytes.Take(arraySegmentBytes.Count).ToArray();
            var result = (TestModel) bytes.FromBytes(type);
            Assert.Equal(
                Tuple.Create(((TestModel) testModel).Id, ((TestModel) testModel).Age,
                    ((TestModel) testModel).CreateTime, ((TestModel) testModel).Name, ((TestModel) testModel).Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}