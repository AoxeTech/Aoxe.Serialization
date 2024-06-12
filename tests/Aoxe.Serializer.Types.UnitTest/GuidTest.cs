namespace Aoxe.Serializer.Types.UnitTest;

public class GuidTest
{
    [Fact]
    public void DataContractGuidSerializeTest() =>
        GuidSerializeTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniGuidSerializeTest() => GuidSerializeTest(new Ini.Serializer());

    [Fact]
    public void JilGuidSerializeTest() => GuidSerializeTest(new Jil.Serializer());

#if !NET48
    [Fact]
    public void MemoryPackGuidSerializeTest() => GuidSerializeTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackGuidSerializeTest() => GuidSerializeTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackGuidSerializeTest() => GuidSerializeTest(new MsgPack.Serializer());

    [Fact]
    public void NetJsonGuidSerializeTest() => GuidSerializeTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonGuidSerializeTest() =>
        GuidSerializeTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufGuidSerializeTest() => GuidSerializeTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlGuidSerializeTest() => GuidSerializeTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonGuidSerializeTest() => GuidSerializeTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonGuidSerializeTest() =>
        GuidSerializeTest(new SystemTextJson.Serializer());

    [Fact]
    public void TomletGuidSerializeTest() => GuidSerializeTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonGuidSerializeTest() => GuidSerializeTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlGuidSerializeTest() => GuidSerializeTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetGuidSerializeTest() => GuidSerializeTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterGuidSerializeTest() =>
        GuidSerializeTest(new ZeroFormatter.Serializer());

    private static void GuidSerializeTest(IBytesSerializer bytesSerializer)
    {
        var guidModel = GuidModel.Instance();
        Assert.Equal(
            guidModel.Id,
            bytesSerializer.FromBytes<GuidModel>(bytesSerializer.ToBytes(guidModel))!.Id
        );
    }
}
