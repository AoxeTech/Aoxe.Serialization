using System.Buffers;

namespace Zaabee.MemoryPack.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeReadOnlySequenceTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = new ReadOnlySequence<byte>(testModel.ToBytes());
        var result = bytes.FromBytes<TestModel>()!;
        
        TestModelHelper.AssertEqual(testModel, result);
    }

    [Fact]
    public void NonGenericTypeReadOnlySequenceTest()
    {
        object testModel = TestModelHelper.Create();
        var bytes = new ReadOnlySequence<byte>(testModel.ToBytes(typeof(TestModel)));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;
        
        TestModelHelper.AssertEqual((TestModel)testModel, result);
    }
}