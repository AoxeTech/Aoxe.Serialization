namespace Zaabee.SystemTextJson.UnitTest;

public partial class SystemTextJsonUnitTest
{
    [Fact]
    public void ReadOnlySpanBytesTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = testModel.ToBytes();
        var result = ((ReadOnlySpan<byte>) bytes).FromBytes<TestModel>()!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }
}