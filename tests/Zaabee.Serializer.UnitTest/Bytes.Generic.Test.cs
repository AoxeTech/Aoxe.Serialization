namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractBytesGenericTest() =>
        BytesGenericTest(new DataContractSerializer.Serializer(), TestModelHelper.Create());

    [Fact]
    public void IniBytesGenericTest() =>
        BytesGenericTest(new Ini.Serializer(), TestModelHelper.Create());

    [Fact]
    public void JilBytesGenericTest() =>
        BytesGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void MemoryPackBytesGenericTest() =>
        BytesGenericTest(new MemoryPack.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void MessagePackBytesGenericTest() =>
        BytesGenericTest(new MessagePack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void MsgPackBytesGenericTest() =>
        BytesGenericTest(new MsgPack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void NewtonsoftJsonBytesGenericTest() =>
        BytesGenericTest(new NewtonsoftJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ProtobufBytesGenericTest() =>
        BytesGenericTest(new Protobuf.Serializer(), TestModelHelper.Create());

    [Fact]
    public void SharpYamlBytesGenericTest() =>
        BytesGenericTest(new SharpYaml.Serializer(), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void SpanJsonBytesGenericTest() =>
        BytesGenericTest(new SpanJson.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void SystemTextJsonBytesGenericTest() =>
        BytesGenericTest(new SystemTextJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void Utf8JsonBytesGenericTest() =>
        BytesGenericTest(new Utf8Json.Serializer(), TestModelHelper.Create());

    [Fact]
    public void XmlBytesGenericTest() =>
        BytesGenericTest(new Xml.Serializer(), TestModelHelper.Create());

    [Fact]
    public void YamlDotNetBytesGenericTest() =>
        BytesGenericTest(new YamlDotNet.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ZeroFormatterBytesGenericTest() =>
        BytesGenericTest(new ZeroFormatter.Serializer(), TestModelHelper.Create());

    private static void BytesGenericTest(IBytesSerializer serializer, TestModel model)
    {
        var bytes = serializer.ToBytes(model);
        var deserializeModel = serializer.FromBytes<TestModel>(bytes)!;
        TestModelHelper.AssertEqual(model, deserializeModel);
    }
}