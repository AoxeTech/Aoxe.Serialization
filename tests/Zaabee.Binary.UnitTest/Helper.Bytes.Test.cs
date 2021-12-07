namespace Zaabee.Binary.UnitTest;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperBytesTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = BinaryHelper.Serialize(testModel);
        var result = (TestModel)BinaryHelper.Deserialize(bytes);
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void HelperSerializeNullTest()
    {
        Assert.Empty(BinaryHelper.Serialize(null));
    }

    [Fact]
    public void HelperDeserializeNullTest()
    {
        Assert.Null(BinaryHelper.Deserialize<TestModel>(null));
    }
}