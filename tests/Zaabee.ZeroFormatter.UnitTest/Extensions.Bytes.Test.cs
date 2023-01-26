namespace Zaabee.ZeroFormatter.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeBytesTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>()!;
        
        Assert.True(TestModelHelper.CompareTestModel(testModel, result));
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
        var bytes = testModel.ToBytes(typeof(TestModel));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;
        
        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result));
    }

    [Fact]
    public void NonGenericTypeBytesNullTest()
    {
        object? nullModel = null;
        Assert.Null(nullModel.ToBytes(typeof(TestModel)).FromBytes(typeof(TestModel)));
        Assert.Null(Array.Empty<byte>().FromBytes(typeof(TestModel)));
    }
}