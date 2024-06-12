namespace Aoxe.Serializer.Types.UnitTest;

public class EnumTest
{
    [Fact]
    public void DataContractEnumSerializeTest() =>
        EnumSerializeTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniEnumSerializeTest() => EnumSerializeTest(new Ini.Serializer());

    [Fact]
    public void JilEnumSerializeTest() => EnumSerializeTest(new Jil.Serializer());

#if !NET48
    [Fact]
    public void MemoryPackEnumSerializeTest() => EnumSerializeTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackEnumSerializeTest() => EnumSerializeTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackEnumSerializeTest() => EnumSerializeTest(new MsgPack.Serializer());

    [Fact]
    public void NetJsonEnumSerializeTest() => EnumSerializeTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonEnumSerializeTest() =>
        EnumSerializeTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufEnumSerializeTest() => EnumSerializeTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlEnumSerializeTest() => EnumSerializeTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonEnumSerializeTest() => EnumSerializeTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonEnumSerializeTest() =>
        EnumSerializeTest(new SystemTextJson.Serializer());

    [Fact]
    public void TomletEnumSerializeTest() => EnumSerializeTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonEnumSerializeTest() => EnumSerializeTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlEnumSerializeTest() => EnumSerializeTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetEnumSerializeTest() => EnumSerializeTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterEnumSerializeTest() =>
        EnumSerializeTest(new ZeroFormatter.Serializer());

    private static void EnumSerializeTest(IBytesSerializer bytesSerializer)
    {
        var colorModel = EnumModel.Instance();
        Assert.Equal(
            colorModel.Color,
            bytesSerializer.FromBytes<EnumModel>(bytesSerializer.ToBytes(colorModel))!.Color
        );
    }
}
