namespace Zaabee.SystemTextJson.UnitTest;

public partial class SystemTextJsonUnitTest
{
    [Fact]
    public void ReadOnlySpanBytesNonGenericTest()
    {
        object testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes(typeof(TestModel));
        var result = (TestModel)((ReadOnlySpan<byte>)bytes).FromBytes(typeof(TestModel))!;

        Assert.Equal((TestModel)testModel, result);
    }
}
