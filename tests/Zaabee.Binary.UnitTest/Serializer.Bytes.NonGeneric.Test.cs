namespace Zaabee.Binary.UnitTest;

public partial class BinarySerializerUnitTest
{
    [Fact]
    public void SerializerBytesNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = BinarySerializer.Serialize(testModel);
        var result = (TestModel)BinarySerializer.Deserialize(bytes);
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void SerializerSerializeNonGenericNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Serialize(null));
    }

    [Fact]
    public void SerializerDeserializeNonGenericNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => (TestModel)BinarySerializer.Deserialize(null));
    }
}