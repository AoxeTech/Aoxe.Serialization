namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void JilStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void MessagePackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void ZeroFormatterStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.ZeroFormatter.Serializer());

    private static void StreamNonGenericNullTest(IStreamSerializer serializer)
    {
        var type = typeof(TestModel);
        var stream = serializer.ToStream(type, null);
        Assert.Equal(0, stream.Length);
        var deserializeModel = serializer.FromStream(type, null);
        Assert.Null(deserializeModel);
    }
}