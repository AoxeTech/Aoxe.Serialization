namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesNonGenericTest() =>
        BytesNonGenericTest(new Binary.Serializer(), TestModelFactory.Create());

    [Fact]
    public void DataContractBytesNonGenericTest() =>
        BytesNonGenericTest(new DataContractSerializer.Serializer(), TestModelFactory.Create());

    [Fact]
    public void JilBytesNonGenericTest() =>
        BytesNonGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelFactory.Create());

    [Fact]
    public void MessagePackBytesNonGenericTest() =>
        BytesNonGenericTest(new MessagePack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void MsgPackBytesNonGenericTest() =>
        BytesNonGenericTest(new MsgPack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void NewtonsoftJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new NewtonsoftJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ProtobufBytesNonGenericTest() =>
        BytesNonGenericTest(new Protobuf.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SharpYamlBytesNonGenericTest() =>
        BytesNonGenericTest(new SharpYaml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SystemTextJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new SystemTextJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void Utf8JsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Utf8Json.Serializer(), TestModelFactory.Create());

    [Fact]
    public void XmlBytesNonGenericTest() =>
        BytesNonGenericTest(new Xml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void YamlDotNetBytesNonGenericTest() =>
        BytesNonGenericTest(new YamlDotNet.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ZeroFormatterBytesNonGenericTest()
    {
        var model = TestModelFactory.Create();
#if NET48
        model.CreateTime = model.CreateTime.ToUniversalTime();
#endif
        BytesNonGenericTest(new ZeroFormatter.Serializer(), model);
    }

    private static void BytesNonGenericTest(IBytesSerializer serializer, TestModel model)
    {
        var type = typeof(TestModel);
        var bytes = serializer.ToBytes(type, model);
        var deserializeModel = (TestModel)serializer.FromBytes(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}