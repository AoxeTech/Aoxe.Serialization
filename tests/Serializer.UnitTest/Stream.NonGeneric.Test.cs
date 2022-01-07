namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void DataContractStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.DataContractSerializer.Serializer());

    [Fact]
    public void JilStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void MessagePackStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void ZeroFormatterStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.ZeroFormatter.Serializer());

    private static void StreamNonGenericTest(IStreamSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.ToStream(type, model);
        var deserializeModel = (TestModel)serializer.FromStream(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}