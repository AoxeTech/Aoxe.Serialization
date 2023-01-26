namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamNonGenericTest() =>
        StreamNonGenericTest(new Binary.Serializer(), TestModelHelper.Create());

    [Fact]
    public void DataContractStreamNonGenericTest() =>
        StreamNonGenericTest(new DataContractSerializer.Serializer(), TestModelHelper.Create());

    [Fact]
    public void JilStreamNonGenericTest() =>
        StreamNonGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

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
        var ms = serializer.ToStream(type, model);
        var deserializeModel = (TestModel)serializer.FromStream(type, ms)!;
        
        Assert.True(TestModelHelper.CompareTestModel(model, deserializeModel));
    }
}