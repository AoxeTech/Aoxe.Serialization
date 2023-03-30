namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamNonGenericTest() =>
        StreamNonGenericTest(new Binary.Serializer(), TestModelHelper.Create());

    [Fact]
    public void IniStreamNonGenericTest() =>
        StreamNonGenericTest(new Ini.Serializer(), TestModelHelper.Create());

    [Fact]
    public void DataContractStreamNonGenericTest() =>
        StreamNonGenericTest(new DataContractSerializer.Serializer(), TestModelHelper.Create());

    [Fact]
    public void JilStreamNonGenericTest() =>
        StreamNonGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void MemoryPackStreamNonGenericTest() =>
        StreamNonGenericTest(new MemoryPack.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void MessagePackStreamNonGenericTest() =>
        StreamNonGenericTest(new MessagePack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void MsgPackStreamNonGenericTest() =>
        StreamNonGenericTest(new MsgPack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new NewtonsoftJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ProtobufStreamNonGenericTest() =>
        StreamNonGenericTest(new Protobuf.Serializer(), TestModelHelper.Create());

    [Fact]
    public void SharpYamlStreamNonGenericTest() =>
        StreamNonGenericTest(new SharpYaml.Serializer(), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void SpanJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new SpanJson.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void SystemTextJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new SystemTextJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void Utf8JsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Utf8Json.Serializer(), TestModelHelper.Create());

    [Fact]
    public void XmlStreamNonGenericTest() =>
        StreamNonGenericTest(new Xml.Serializer(), TestModelHelper.Create());

    [Fact]
    public void YamlDotNetStreamNonGenericTest() =>
        StreamNonGenericTest(new YamlDotNet.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ZeroFormatterStreamNonGenericTest() =>
        StreamNonGenericTest(new ZeroFormatter.Serializer(), TestModelHelper.Create());

    private static void StreamNonGenericTest(IStreamSerializer serializer, TestModel model)
    {
        var type = typeof(TestModel);
        var stream0 = serializer.ToStream(type, model);
        var stream1 = new MemoryStream();
        serializer.Pack(type, model, stream1);
        var deserializeModel0 = (TestModel)serializer.FromStream(type, stream0)!;
        var deserializeModel1 = (TestModel)serializer.FromStream(type, stream1)!;

        TestModelHelper.AssertEqual(model, deserializeModel0);
        TestModelHelper.AssertEqual(model, deserializeModel1);
    }
}