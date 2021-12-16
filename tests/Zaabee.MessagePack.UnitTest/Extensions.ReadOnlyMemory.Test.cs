namespace Zaabee.MessagePack.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeReadOnlyMemoryTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = new ReadOnlyMemory<byte>(testModel.ToBytes());
        var result = bytes.FromBytes<TestModel>()!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
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
        object testModel = TestModelFactory.Create();
        var bytes = new ReadOnlyMemory<byte>(testModel.ToBytes(typeof(TestModel)));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void NonGenericTypeReadOnlyMemoryNullTest()
    {
        ReadOnlyMemory<byte> bytes = null;
        Assert.Null(bytes.FromBytes(typeof(TestModel)));
    }
}