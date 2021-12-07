namespace Zaabee.Binary.UnitTest;

public partial class BinarySerializerUnitTest
{
    [Fact]
    public void SerializerStreamTest()
    {
        var testModel = TestModelFactory.Create();

        var stream = BinarySerializer.Pack(testModel);

        var unPackResult = BinarySerializer.Unpack<TestModel>(stream);

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult.Id, unPackResult.Age, unPackResult.CreateTime, unPackResult.Name,
                unPackResult.Gender));
    }

    [Fact]
    public void SerializerStreamPackNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Pack(null));
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Pack(null, new MemoryStream()));
    }

    [Fact]
    public void SerializerStreamUnpackNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Unpack<TestModel>(null));
    }
}