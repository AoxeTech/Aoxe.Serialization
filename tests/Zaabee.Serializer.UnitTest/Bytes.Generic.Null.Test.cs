namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesGenericNullTest() =>
        BytesGenericNullTest(new Binary.Serializer());

    [Fact]
    public void JilBytesGenericNullTest() =>
        BytesGenericNullTest(new Jil.Serializer());

    [Fact]
    public void MessagePackBytesGenericNullTest() =>
        BytesGenericNullTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesGenericNullTest() =>
        BytesGenericNullTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesGenericNullTest() =>
        BytesGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesGenericNullTest() =>
        BytesGenericNullTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlBytesGenericNullTest() =>
        BytesGenericNullTest(new SharpYaml.Serializer());

    [Fact]
    public void SystemTextJsonBytesGenericNullTest() =>
        BytesGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonBytesGenericNullTest() =>
        BytesGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlBytesGenericNullTest() =>
        BytesGenericNullTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetBytesGenericNullTest() =>
        BytesGenericNullTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterBytesGenericNullTest() =>
        BytesGenericNullTest(new ZeroFormatter.Serializer());

    private static void BytesGenericNullTest(IBytesSerializer serializer)
    {
        TestModel? model = null;
        var bytes = serializer.ToBytes(model);
        var deserializeModel = serializer.FromBytes<TestModel>(bytes);
        Assert.Null(deserializeModel);
    }
}