namespace Aoxe.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractBytesNonGenericTest() =>
        BytesNonGenericTest(new DataContractSerializer.Serializer(), TestModelHelper.Create());

    [Fact]
    public void IniBytesNonGenericTest() =>
        BytesNonGenericTest(new Ini.Serializer(), TestModelHelper.Create());

    [Fact]
    public void JilBytesNonGenericTest() =>
        BytesNonGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void MemoryPackBytesNonGenericTest() =>
        BytesNonGenericTest(new MemoryPack.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void MessagePackBytesNonGenericTest() =>
        BytesNonGenericTest(new MessagePack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void MsgPackBytesNonGenericTest() =>
        BytesNonGenericTest(new MsgPack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void NetJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new NetJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void NewtonsoftJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new NewtonsoftJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ProtobufBytesNonGenericTest() =>
        BytesNonGenericTest(new Protobuf.Serializer(), TestModelHelper.Create());

    [Fact]
    public void SharpYamlBytesNonGenericTest() =>
        BytesNonGenericTest(new SharpYaml.Serializer(), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void SpanJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new SpanJson.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void SystemTextJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new SystemTextJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void TomletBytesNonGenericTest() =>
        BytesNonGenericTest(new Tomlet.Serializer(), TestModelHelper.Create());

    [Fact]
    public void Utf8JsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Utf8Json.Serializer(), TestModelHelper.Create());

    [Fact]
    public void XmlBytesNonGenericTest() =>
        BytesNonGenericTest(new Xml.Serializer(), TestModelHelper.Create());

    [Fact]
    public void YamlDotNetBytesNonGenericTest() =>
        BytesNonGenericTest(new YamlDotNet.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ZeroFormatterBytesNonGenericTest() =>
        BytesNonGenericTest(new ZeroFormatter.Serializer(), TestModelHelper.Create());

    private static void BytesNonGenericTest(IBytesSerializer serializer, TestModel model)
    {
        var type = typeof(TestModel);
        var bytes = serializer.ToBytes(type, model);
        var deserializeModel = (TestModel)serializer.FromBytes(type, bytes)!;

        Assert.Equal(model, deserializeModel);
    }
}
