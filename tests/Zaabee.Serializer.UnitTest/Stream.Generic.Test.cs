namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamGenericTest() =>
        StreamGenericTest(new Binary.Serializer());

    [Fact]
    public void DataContractStreamGenericTest() =>
        StreamGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilStreamGenericTest() =>
        StreamGenericTest(new Jil.Serializer(Options.ISO8601Utc));

    [Fact]
    public void MessagePackStreamGenericTest() =>
        StreamGenericTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamGenericTest() =>
        StreamGenericTest(new MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamGenericTest() =>
        StreamGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamGenericTest() =>
        StreamGenericTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlStreamGenericTest() =>
        StreamGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void SystemTextJsonStreamGenericTest() =>
        StreamGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamGenericTest() =>
        StreamGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlStreamGenericTest() =>
        StreamGenericTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetStreamGenericTest() =>
        StreamGenericTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterStreamGenericTest() =>
        StreamGenericTest(new ZeroFormatter.Serializer());

    private static void StreamGenericTest(IStreamSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var stream = serializer.ToStream(model);
        var deserializeModel = serializer.FromStream<TestModel>(stream)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}