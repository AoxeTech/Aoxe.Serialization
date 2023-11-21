namespace Zaabee.SystemTextJson.UnitTest;

public partial class SystemTextJsonUnitTest
{
    [Fact]
    public void ReadOnlySpanBytesTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes();
        var result = ((ReadOnlySpan<byte>)bytes).FromBytes<TestModel>()!;
        
        Assert.Equal(testModel, result);
    }
}