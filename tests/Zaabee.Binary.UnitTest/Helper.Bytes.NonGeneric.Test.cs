namespace Zaabee.Binary.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperBytesNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = BinaryHelper.ToBytes(testModel);
        var result = (TestModel)BinaryHelper.FromBytes(bytes);
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void HelperSerializeNonGenericNullTest()
    {
        Assert.Empty(BinaryHelper.ToBytes(null));
    }

    [Fact]
    public void HelperDeserializeNonGenericNullTest()
    {
        Assert.Null(BinaryHelper.FromBytes(null));
    }
}