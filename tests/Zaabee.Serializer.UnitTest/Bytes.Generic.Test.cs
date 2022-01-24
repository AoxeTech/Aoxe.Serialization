namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesGenericTest() =>
        BytesGenericTest(new Binary.Serializer(), TestModelFactory.Create());

    [Fact]
    public void DataContractBytesGenericTest() =>
        BytesGenericTest(new DataContractSerializer.Serializer(), TestModelFactory.Create());

    [Fact]
    public void JilBytesGenericTest() =>
        BytesGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelFactory.Create());

    [Fact]
    public void MessagePackBytesGenericTest() =>
        BytesGenericTest(new MessagePack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void MsgPackBytesGenericTest() =>
        BytesGenericTest(new MsgPack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void NewtonsoftJsonBytesGenericTest() =>
        BytesGenericTest(new NewtonsoftJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ProtobufBytesGenericTest() =>
        BytesGenericTest(new Protobuf.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SharpYamlBytesGenericTest() =>
        BytesGenericTest(new SharpYaml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SystemTextJsonBytesGenericTest() =>
        BytesGenericTest(new SystemTextJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void Utf8JsonBytesGenericTest() =>
        BytesGenericTest(new Utf8Json.Serializer(), TestModelFactory.Create());

    [Fact]
    public void XmlBytesGenericTest() =>
        BytesGenericTest(new Xml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void YamlDotNetBytesGenericTest() =>
        BytesGenericTest(new YamlDotNet.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ZeroFormatterBytesGenericTest()
    {
        var model = TestModelFactory.Create();
#if NET48
        model.CreateTime = model.CreateTime.ToUniversalTime();
#endif
        BytesGenericTest(new ZeroFormatter.Serializer(), model);
    }

    private static void BytesGenericTest(IBytesSerializer serializer, TestModel model)
    {
        var bytes = serializer.ToBytes(model);
        var deserializeModel = serializer.FromBytes<TestModel>(bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}