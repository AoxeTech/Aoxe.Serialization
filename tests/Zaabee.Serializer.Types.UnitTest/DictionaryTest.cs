namespace Zaabee.Serializer.Types.UnitTest;

public class DictionaryTest
{
    [Fact]
    public void DataContractDictionarySerializeTest() =>
        DictionarySerializeTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniDictionarySerializeTest() =>
        DictionarySerializeTest(new Ini.Serializer());

    [Fact]
    public void JilDictionarySerializeTest() =>
        DictionarySerializeTest(new Jil.Serializer());

#if !NET48
    [Fact]
    public void MemoryPackDictionarySerializeTest() =>
        DictionarySerializeTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackDictionarySerializeTest() =>
        DictionarySerializeTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackDictionarySerializeTest() =>
        DictionarySerializeTest(new MsgPack.Serializer());

    [Fact]
    public void NetJsonDictionarySerializeTest() =>
        DictionarySerializeTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonDictionarySerializeTest() =>
        DictionarySerializeTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufDictionarySerializeTest() =>
        DictionarySerializeTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlDictionarySerializeTest() =>
        DictionarySerializeTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonDictionarySerializeTest() =>
        DictionarySerializeTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonDictionarySerializeTest() =>
        DictionarySerializeTest(new SystemTextJson.Serializer());

    [Fact]
    public void TomletDictionarySerializeTest() =>
        DictionarySerializeTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonDictionarySerializeTest() =>
        DictionarySerializeTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlDictionarySerializeTest() =>
        DictionarySerializeTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetDictionarySerializeTest() =>
        DictionarySerializeTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterDictionarySerializeTest() =>
        DictionarySerializeTest(new ZeroFormatter.Serializer());

    private static void DictionarySerializeTest(IBytesSerializer bytesSerializer)
    {
        var dictionaryModel = DictionaryModel.Instance();
        dictionaryModel.Dictionary.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        Assert.Equal(dictionaryModel.Dictionary.Count, bytesSerializer.FromBytes<DictionaryModel>(bytesSerializer.ToBytes(dictionaryModel))!.Dictionary.Count);
        Assert.Equal(dictionaryModel.Dictionary.First().Key, bytesSerializer.FromBytes<DictionaryModel>(bytesSerializer.ToBytes(dictionaryModel))!.Dictionary.First().Key);
        Assert.Equal(dictionaryModel.Dictionary.First().Value, bytesSerializer.FromBytes<DictionaryModel>(bytesSerializer.ToBytes(dictionaryModel))!.Dictionary.First().Value);
    }
}