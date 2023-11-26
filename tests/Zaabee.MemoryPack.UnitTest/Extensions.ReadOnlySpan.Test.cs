namespace Zaabee.MemoryPack.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeReadOnlySpanTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = new ReadOnlySpan<byte>(testModel.ToBytes());
        var result = bytes.FromBytes<TestModel>()!;

        Assert.Equal(testModel, result);
    }

    [Fact]
    public void GenericTypeReadOnlySpanNullTest()
    {
        ReadOnlySpan<byte> bytes = null;
        Assert.Null(bytes.FromBytes<TestModel>());
    }

    [Fact]
    public void NonGenericTypeReadOnlySpanTest()
    {
        object testModel = TestModelHelper.Create();
        var bytes = new ReadOnlySpan<byte>(testModel.ToBytes(typeof(TestModel)));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;

        Assert.Equal((TestModel)testModel, result);
    }

    [Fact]
    public void NonGenericTypeReadOnlySpanNullTest()
    {
        ReadOnlySpan<byte> bytes = null;
        Assert.Null(bytes.FromBytes(typeof(TestModel)));
    }
}