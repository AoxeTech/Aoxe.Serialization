namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamGenericTest() =>
        StreamGenericTest(new Binary.Serializer(), TestModelHelper.Create());

    [Fact]
    public void DataContractStreamGenericTest() =>
        StreamGenericTest(new DataContractSerializer.Serializer(), TestModelHelper.Create());

    [Fact]
    public void JilStreamGenericTest() =>
        StreamGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

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
        var stream = serializer.ToStream(model);
        var deserializeModel = serializer.FromStream<TestModel>(stream)!;

        TestModelHelper.AssertEqual(model, deserializeModel);
    }
}