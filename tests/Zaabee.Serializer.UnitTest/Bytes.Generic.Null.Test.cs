namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractGenericNullTest() =>
        BytesGenericNullTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniBytesGenericNullTest() => BytesGenericNullTest(new Ini.Serializer());

    [Fact]
    public void JilBytesGenericNullTest() => BytesGenericNullTest(new Jil.Serializer());

#if !NET48
    [Fact]
    public void MemoryPackBytesGenericNullTest() =>
        BytesGenericNullTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackBytesGenericNullTest() =>
        BytesGenericNullTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesGenericNullTest() => BytesGenericNullTest(new MsgPack.Serializer());

    [Fact]
    public void NetJsonBytesGenericNullTest() => BytesGenericNullTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesGenericNullTest() =>
        BytesGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesGenericNullTest() => BytesGenericNullTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlBytesGenericNullTest() => BytesGenericNullTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonBytesGenericNullTest() => BytesGenericNullTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonBytesGenericNullTest() =>
        BytesGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void TomletBytesGenericNullTest() => BytesGenericNullTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonBytesGenericNullTest() => BytesGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlBytesGenericNullTest() => BytesGenericNullTest(new Xml.Serializer());

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
