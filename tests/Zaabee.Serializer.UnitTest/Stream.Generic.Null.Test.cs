namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void IniStreamGenericNullTest() => StreamGenericNullTest(new Ini.Serializer());

    [Fact]
    public void JilStreamGenericNullTest() => StreamGenericNullTest(new Jil.Serializer());

#if !NET48
    [Fact]
    public void MemoryPackStreamGenericNullTest() =>
        StreamGenericNullTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackStreamGenericNullTest() =>
        StreamGenericNullTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamGenericNullTest() => StreamGenericNullTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamGenericNullTest() =>
        StreamGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void NetJsonStreamGenericNullTest() => StreamGenericNullTest(new NetJson.Serializer());

    [Fact]
    public void ProtobufStreamGenericNullTest() => StreamGenericNullTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlStreamGenericNullTest() =>
        StreamGenericNullTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonStreamGenericNullTest() => StreamGenericNullTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonStreamGenericNullTest() =>
        StreamGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void SharpSerializerStreamGenericNullTest() =>
        StreamGenericNullTest(new SharpSerializer.Serializer());

    [Fact]
    public void TomletStreamGenericNullTest() => StreamGenericNullTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonStreamGenericNullTest() => StreamGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlStreamGenericNullTest() => StreamGenericNullTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetStreamGenericNullTest() =>
        StreamGenericNullTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterStreamGenericNullTest() =>
        StreamGenericNullTest(new ZeroFormatter.Serializer());

    private static void StreamGenericNullTest(IStreamSerializer serializer)
    {
        TestModel? model = null;
        var stream = serializer.ToStream(model);
        var deserializeModel = serializer.FromStream<TestModel>(stream);
        Assert.Null(deserializeModel);
    }
}
