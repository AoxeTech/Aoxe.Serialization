namespace Zaabee.ZeroFormatter.UnitTest;

public partial class BinaryExtensionsUnitTest
{
    [Fact]
    public void ExtensionsBytesNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = testModel.ToBytes(typeof(TestModel));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void ExtensionsSerializeNonGenericNullTest()
    {
        TestModel? nullValue = null;
        var bytes = nullValue.ToBytes(typeof(TestModel));
    }

    [Fact]
    public void ExtensionsDeserializeNonGenericNullTest()
    {
        byte[]? nullBytes = null;
        Assert.Null(nullBytes.FromBytes(typeof(TestModel)));
    }
}