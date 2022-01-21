namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamNonGenericTest() =>
        StreamNonGenericTest(new Binary.Serializer());

    [Fact]
    public void DataContractStreamNonGenericTest() =>
        StreamNonGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilStreamNonGenericTest() =>
        StreamNonGenericTest(new Jil.Serializer());

    [Fact]
    public void MessagePackStreamNonGenericTest() =>
        StreamNonGenericTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamNonGenericTest() =>
        StreamNonGenericTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamNonGenericTest() =>
        StreamNonGenericTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlStreamNonGenericTest() =>
        StreamNonGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void SystemTextJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlStreamNonGenericTest() =>
        StreamNonGenericTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetStreamNonGenericTest() =>
        StreamNonGenericTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterStreamNonGenericTest() =>
        StreamNonGenericTest(new ZeroFormatter.Serializer());

    private static void StreamNonGenericTest(IStreamSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.ToStream(type, model);
        var deserializeModel = (TestModel)serializer.FromStream(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime.ToUniversalTime(),
                deserializeModel.Name, deserializeModel.Gender));
    }
}