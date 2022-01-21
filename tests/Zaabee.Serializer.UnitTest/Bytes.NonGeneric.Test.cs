namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesNonGenericTest() =>
        BytesNonGenericTest(new Binary.Serializer());

    [Fact]
    public void DataContractBytesNonGenericTest() =>
        BytesNonGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilBytesNonGenericTest() =>
        BytesNonGenericTest(new Jil.Serializer());

    [Fact]
    public void MessagePackBytesNonGenericTest() =>
        BytesNonGenericTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesNonGenericTest() =>
        BytesNonGenericTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesNonGenericTest() =>
        BytesNonGenericTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlBytesNonGenericTest() =>
        BytesNonGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void SystemTextJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlBytesNonGenericTest() =>
        BytesNonGenericTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetBytesNonGenericTest() =>
        BytesNonGenericTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterBytesNonGenericTest() =>
        BytesNonGenericTest(new ZeroFormatter.Serializer());

    private static void BytesNonGenericTest(IBytesSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.ToBytes(type, model);
        var deserializeModel = (TestModel)serializer.FromBytes(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime.ToUniversalTime(),
                deserializeModel.Name, deserializeModel.Gender));
    }
}