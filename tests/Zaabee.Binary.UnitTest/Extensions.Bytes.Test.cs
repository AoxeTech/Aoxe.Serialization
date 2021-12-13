namespace Zaabee.Binary.UnitTest;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
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
        Assert.Empty(nullValue.ToBytes());
    }

    [Fact]
    public void ExtensionsDeserializeNullTest()
    {
        byte[]? nullBytes = null;
        Assert.Null(nullBytes.FromBytes<TestModel>());
    }
}