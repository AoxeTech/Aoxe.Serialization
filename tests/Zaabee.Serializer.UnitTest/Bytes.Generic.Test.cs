namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesGenericTest() =>
        BytesGenericTest(new Binary.Serializer());

    [Fact]
    public void DataContractBytesGenericTest() =>
        BytesGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilBytesGenericTest() =>
        BytesGenericTest(new Jil.Serializer());

    [Fact]
    public void MessagePackBytesGenericTest() =>
        BytesGenericTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesGenericTest() =>
        BytesGenericTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesGenericTest() =>
        BytesGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesGenericTest() =>
        BytesGenericTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlBytesGenericTest() =>
        BytesGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void SystemTextJsonBytesGenericTest() =>
        BytesGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonBytesGenericTest() =>
        BytesGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlBytesGenericTest() =>
        BytesGenericTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetBytesGenericTest() =>
        BytesGenericTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterBytesGenericTest() =>
        BytesGenericTest(new ZeroFormatter.Serializer());

    private static void BytesGenericTest(IBytesSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var bytes = serializer.ToBytes(model);
        var deserializeModel = serializer.FromBytes<TestModel>(bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime.ToUniversalTime(),
                deserializeModel.Name, deserializeModel.Gender));
    }
}