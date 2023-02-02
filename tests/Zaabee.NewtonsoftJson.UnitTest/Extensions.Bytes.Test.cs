namespace Zaabee.NewtonsoftJson.UnitTest;

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
        byte[]? nullBytes = null;
        Assert.Null(nullModel.ToBytes().FromBytes<TestModel>());
        Assert.Null(Array.Empty<byte>().FromBytes<TestModel>());
        Assert.Null(nullBytes.FromBytes<TestModel>());
    }

    [Fact]
    public void NonGenericTypeBytesTest()
    {
        object testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes(typeof(TestModel));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;
        
        TestModelHelper.AssertEqual((TestModel)testModel, result);
    }

    [Fact]
    public void NonGenericTypeBytesNullTest()
    {
        object? nullModel = null;
        byte[]? nullBytes = null;
        Assert.Null(nullModel.ToBytes(typeof(TestModel)).FromBytes(typeof(TestModel)));
        Assert.Null(Array.Empty<byte>().FromBytes(typeof(TestModel)));
        Assert.Null(nullBytes.FromBytes(typeof(TestModel)));
    }
}