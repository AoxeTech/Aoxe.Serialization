namespace Zaabee.Binary.UnitTest;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
public partial class BinarySerializerUnitTest
{
    [Fact]
    public void SerializerBytesTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = BinarySerializer.Serialize(testModel);
        var result = BinarySerializer.Deserialize<TestModel>(bytes);
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void SerializerSerializeNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Serialize(null));
    }

    [Fact]
    public void SerializerDeserializeNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => BinarySerializer.Deserialize<TestModel>(null));
    }
}