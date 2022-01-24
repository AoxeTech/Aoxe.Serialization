namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamGenericTest() =>
        StreamGenericTest(new Binary.Serializer(), TestModelFactory.Create());

    [Fact]
    public void DataContractStreamGenericTest() =>
        StreamGenericTest(new DataContractSerializer.Serializer(), TestModelFactory.Create());

    [Fact]
    public void JilStreamGenericTest() =>
        StreamGenericTest(new Jil.Serializer(Options.ISO8601Utc), TestModelFactory.Create());

    [Fact]
    public void MessagePackStreamGenericTest() =>
        StreamGenericTest(new MessagePack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void MsgPackStreamGenericTest() =>
        StreamGenericTest(new MsgPack.Serializer(), TestModelFactory.Create());

    [Fact]
    public void NewtonsoftJsonStreamGenericTest() =>
        StreamGenericTest(new NewtonsoftJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ProtobufStreamGenericTest() =>
        StreamGenericTest(new Protobuf.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SharpYamlStreamGenericTest() =>
        StreamGenericTest(new SharpYaml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void SystemTextJsonStreamGenericTest() =>
        StreamGenericTest(new SystemTextJson.Serializer(), TestModelFactory.Create());

    [Fact]
    public void Utf8JsonStreamGenericTest() =>
        StreamGenericTest(new Utf8Json.Serializer(), TestModelFactory.Create());

    [Fact]
    public void XmlStreamGenericTest() =>
        StreamGenericTest(new Xml.Serializer(), TestModelFactory.Create());

    [Fact]
    public void YamlDotNetStreamGenericTest() =>
        StreamGenericTest(new YamlDotNet.Serializer(), TestModelFactory.Create());

    [Fact]
    public void ZeroFormatterStreamGenericTest()
    {
        var model = TestModelFactory.Create();
#if NET48
        model.CreateTime = model.CreateTime.ToUniversalTime();
#endif
        StreamGenericTest(new ZeroFormatter.Serializer(), model);
    }

    private static void StreamGenericTest(IStreamSerializer serializer, TestModel model)
    {
        var stream = serializer.ToStream(model);
        var deserializeModel = serializer.FromStream<TestModel>(stream)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}