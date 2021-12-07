namespace Zaabee.Binary.UnitTest;

public partial class BinaryExtensionsUnitTest
{
    [Fact]
    public void ExtensionsBytesNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = testModel.ToBytes();
        var result = (TestModel) bytes.FromBytes();
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void ExtensionsSerializeNonGenericNullTest()
    {
        TestModel? nullValue = null;
        Assert.Empty(nullValue.ToBytes());
    }

    [Fact]
    public void ExtensionsDeserializeNonGenericNullTest()
    {
        byte[]? nullBytes = null;
        Assert.Null(nullBytes.FromBytes());
    }
}