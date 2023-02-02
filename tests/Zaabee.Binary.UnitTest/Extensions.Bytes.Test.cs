namespace Zaabee.Binary.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeBytesTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>()!;
        TestModelHelper.AssertEqual(testModel, result);
    }

    [Fact]
    public void GenericTypeBytesNullTest()
    {
        TestModel? nullModel = null;
        Assert.Null(nullModel.ToBytes().FromBytes<TestModel>());
        Assert.Null(Array.Empty<byte>().FromBytes<TestModel>());
    }

    [Fact]
    public void NonGenericTypeBytesTest()
    {
        object testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes();
        var result = (TestModel)bytes.FromBytes()!;
        TestModelHelper.AssertEqual((TestModel)testModel, result);
    }

    [Fact]
    public void NonGenericTypeBytesNullTest()
    {
        object? nullModel = null;
        Assert.Null(nullModel.ToBytes().FromBytes());
        Assert.Null(Array.Empty<byte>().FromBytes());
    }
}