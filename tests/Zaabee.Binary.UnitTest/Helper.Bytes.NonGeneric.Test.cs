namespace Zaabee.Binary.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperBytesNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = BinaryHelper.Serialize(testModel);
        var result = (TestModel)BinaryHelper.Deserialize(bytes);
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void HelperSerializeNonGenericNullTest()
    {
        Assert.Empty(BinaryHelper.Serialize(null));
    }

    [Fact]
    public void HelperDeserializeNonGenericNullTest()
    {
        Assert.Null(BinaryHelper.Deserialize(null));
    }
}