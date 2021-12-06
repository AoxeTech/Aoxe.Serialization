namespace Zaabee.Binary.UnitTest;

public partial class BinaryUnitTest
{
    [Fact]
    public void BytesTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>();
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void SerializeNullTest()
    {
        Assert.Empty(BinaryHelper.Serialize(null));
    }

    [Fact]
    public void DeserializeNullTest()
    {
        Assert.Null(BinaryHelper.Deserialize<TestModel>(null));
    }
}