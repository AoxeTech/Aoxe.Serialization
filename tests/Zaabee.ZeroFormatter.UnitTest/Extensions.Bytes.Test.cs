namespace Zaabee.ZeroFormatter.UnitTest;

public partial class BinaryExtensionsUnitTest
{
    [Fact]
    public void ExtensionsBytesTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>()!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void ExtensionsSerializeNullTest()
    {
        TestModel? nullValue = null;
        var bytes = nullValue.ToBytes();
    }

    [Fact]
    public void ExtensionsDeserializeNullTest()
    {
        byte[]? nullBytes = null;
        Assert.Null(nullBytes.FromBytes<TestModel>());
    }
}