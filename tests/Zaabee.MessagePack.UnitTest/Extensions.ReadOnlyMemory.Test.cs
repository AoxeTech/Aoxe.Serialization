namespace Zaabee.MessagePack.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeReadOnlyMemoryTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = new ReadOnlyMemory<byte>(testModel.ToBytes());
        var result = bytes.FromBytes<TestModel>()!;
        
        TestModelHelper.AssertEqual(testModel, result);
    }

    [Fact]
    public void GenericTypeReadOnlyMemoryNullTest()
    {
        ReadOnlyMemory<byte> bytes = null;
        Assert.Null(bytes.FromBytes<TestModel>());
    }

    [Fact]
    public void NonGenericTypeReadOnlyMemoryTest()
    {
        object testModel = TestModelHelper.Create();
        var bytes = new ReadOnlyMemory<byte>(testModel.ToBytes(typeof(TestModel)));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;
        
        TestModelHelper.AssertEqual((TestModel)testModel, result);
    }

    [Fact]
    public void NonGenericTypeReadOnlyMemoryNullTest()
    {
        ReadOnlyMemory<byte> bytes = null;
        Assert.Null(bytes.FromBytes(typeof(TestModel)));
    }
}