namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamNonGenericTest() =>
        StreamNonGenericTest(new Binary.Serializer(), TestModelFactory.Create());

    [Fact]
    public void DataContractStreamNonGenericTest() =>
        StreamNonGenericTest(new DataContractSerializer.Serializer(), TestModelFactory.Create());

    [Fact]
    public void JilStreamNonGenericTest() =>
        StreamNonGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelFactory.Create());

    [Fact]
    public void MessagePackStreamNonGenericTest() =>
        StreamNonGenericTest(new MessagePack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void MsgPackStreamNonGenericTest() =>
        StreamNonGenericTest(new MsgPack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new NewtonsoftJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ProtobufStreamNonGenericTest() =>
        StreamNonGenericTest(new Protobuf.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SharpYamlStreamNonGenericTest() =>
        StreamNonGenericTest(new SharpYaml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SystemTextJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new SystemTextJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void Utf8JsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Utf8Json.Serializer(), TestModelFactory.Create());

    [Fact]
    public void XmlStreamNonGenericTest() =>
        StreamNonGenericTest(new Xml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void YamlDotNetStreamNonGenericTest() =>
        StreamNonGenericTest(new YamlDotNet.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ZeroFormatterStreamNonGenericTest()
    {
        var model = TestModelFactory.Create();
#if NET48
        model.CreateTime = model.CreateTime.ToUniversalTime();
#endif
        StreamNonGenericTest(new ZeroFormatter.Serializer(), model);
    }

    private static void StreamNonGenericTest(IStreamSerializer serializer, TestModel model)
    {
        var type = typeof(TestModel);
        var ms = serializer.ToStream(type, model);
        var deserializeModel = (TestModel)serializer.FromStream(type, ms)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}