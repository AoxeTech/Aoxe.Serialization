namespace Zaabee.Binary.UnitTest;

public partial class BinarySerializerUnitTest
{
    [Fact]
    public void SerializerStreamNonGenericTest()
    {
        var testModel = TestModelFactory.Create();

        var stream = BinarySerializer.Pack(testModel);

        var unPackResult = (TestModel)BinarySerializer.Unpack(stream);

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult.Id, unPackResult.Age, unPackResult.CreateTime, unPackResult.Name,
                unPackResult.Gender));
    }

    [Fact]
    public void SerializerStreamPackNonGenericNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Pack(null));
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Pack(null, new MemoryStream()));
    }

    [Fact]
    public void SerializerStreamUnpackNonGenericNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => (TestModel)BinarySerializer.Unpack(null));
    }
}