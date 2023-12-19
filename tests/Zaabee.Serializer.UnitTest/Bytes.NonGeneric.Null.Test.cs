namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniBytesNonGenericNullTest() => BytesNonGenericNullTest(new Ini.Serializer());

    [Fact]
    public void JilBytesNonGenericNullTest() => BytesNonGenericNullTest(new Jil.Serializer());

#if !NET48
    [Fact]
    public void MemoryPackBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new MsgPack.Serializer());

    [Fact]
    public void NetJsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void SharpSerializerBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new SharpSerializer.Serializer());

    [Fact]
    public void TomletBytesNonGenericNullTest() => BytesNonGenericNullTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlBytesNonGenericNullTest() => BytesNonGenericNullTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterBytesNonGenericNullTest() =>
        BytesNonGenericNullTest(new ZeroFormatter.Serializer());

    private static void BytesNonGenericNullTest(IBytesSerializer serializer)
    {
        var type = typeof(TestModel);
        var bytes = serializer.ToBytes(type, null);
        var deserializeModel = serializer.FromBytes(type, bytes);
        Assert.Null(deserializeModel);
    }
}
