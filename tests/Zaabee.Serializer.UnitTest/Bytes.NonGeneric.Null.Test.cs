namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new Binary.Serializer());

    [Fact]
    public void JilBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new Jil.Serializer());

    [Fact]
    public void MessagePackBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new Xml.Serializer());

    [Fact]
    public void ZeroFormatterBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new ZeroFormatter.Serializer());

    private static void BytesNonGenericNullTest(IBytesSerializer serializer)
    {
        var type = typeof(TestModel);
        var bytes = serializer.ToBytes(type, null);
        Assert.Empty(bytes);
        var deserializeModel = serializer.FromBytes(type, null);
        Assert.Null(deserializeModel);
    }
}