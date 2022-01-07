namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void JilStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void MessagePackStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void ZeroFormatterStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.ZeroFormatter.Serializer());

    private static void StreamGenericNullTest(IStreamSerializer serializer)
    {
        TestModel? model = null;
        var stream = serializer.ToStream(model);
        Assert.Equal(0, stream.Length);
        var deserializeModel = serializer.FromStream<TestModel>(null);
        Assert.Null(deserializeModel);
    }
}