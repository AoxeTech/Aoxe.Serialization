namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Binary.Serializer());

    [Fact]
    public void JilStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Jil.Serializer());

    [Fact]
    public void MessagePackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Xml.Serializer());

    [Fact]
    public void ZeroFormatterStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new ZeroFormatter.Serializer());

    private static void StreamNonGenericNullTest(IStreamSerializer serializer)
    {
        var type = typeof(TestModel);
        var stream = serializer.ToStream(type, null);
        var deserializeModel = serializer.FromStream(type, stream);
        Assert.Null(deserializeModel);
    }
}