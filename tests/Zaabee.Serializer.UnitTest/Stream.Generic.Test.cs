namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractStreamGenericTest() =>
        StreamGenericTest(new DataContractSerializer.Serializer(), TestModelHelper.Create());

    [Fact]
    public void IniStreamGenericTest() =>
        StreamGenericTest(new Ini.Serializer(), TestModelHelper.Create());

    [Fact]
    public void JilStreamGenericTest() =>
        StreamGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void MemoryPackStreamGenericTest() =>
        StreamGenericTest(new MemoryPack.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void MessagePackStreamGenericTest() =>
        StreamGenericTest(new MessagePack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void MsgPackStreamGenericTest() =>
        StreamGenericTest(new MsgPack.Serializer(), TestModelHelper.Create());

    [Fact]
    public void NewtonsoftJsonStreamGenericTest() =>
        StreamGenericTest(new NewtonsoftJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ProtobufStreamGenericTest() =>
        StreamGenericTest(new Protobuf.Serializer(), TestModelHelper.Create());

    [Fact]
    public void SharpYamlStreamGenericTest() =>
        StreamGenericTest(new SharpYaml.Serializer(), TestModelHelper.Create());

#if !NET48
    [Fact]
    public void SpanJsonStreamGenericTest() =>
        StreamGenericTest(new SpanJson.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public void SystemTextJsonStreamGenericTest() =>
        StreamGenericTest(new SystemTextJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public void Utf8JsonStreamGenericTest() =>
        StreamGenericTest(new Utf8Json.Serializer(), TestModelHelper.Create());

    [Fact]
    public void XmlStreamGenericTest() =>
        StreamGenericTest(new Xml.Serializer(), TestModelHelper.Create());

    [Fact]
    public void YamlDotNetStreamGenericTest() =>
        StreamGenericTest(new YamlDotNet.Serializer(), TestModelHelper.Create());

    [Fact]
    public void ZeroFormatterStreamGenericTest() =>
        StreamGenericTest(new ZeroFormatter.Serializer(), TestModelHelper.Create());

    private static void StreamGenericTest(IStreamSerializer serializer, TestModel model)
    {
        var stream0 = serializer.ToStream(model);
        var stream1 = new MemoryStream();
        serializer.Pack(model, stream1);
        var deserializeModel0 = serializer.FromStream<TestModel>(stream0)!;
        var deserializeModel1 = serializer.FromStream<TestModel>(stream1)!;

        TestModelHelper.AssertEqual(model, deserializeModel0);
        TestModelHelper.AssertEqual(model, deserializeModel1);
    }
}