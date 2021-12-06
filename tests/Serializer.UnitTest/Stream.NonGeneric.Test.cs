namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void BinaryStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Binary.ZaabeeSerializer());

    [Fact]
    public void JilStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Jil.ZaabeeSerializer());

    [Fact]
    public void MessagePackStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.MessagePack.ZaabeeSerializer());

    [Fact]
    public void MsgPackStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.MsgPack.ZaabeeSerializer());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

    [Fact]
    public void ProtobufStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Protobuf.ZaabeeSerializer());

    [Fact]
    public void SystemTextJsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

    [Fact]
    public void Utf8JsonStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Utf8Json.ZaabeeSerializer());

    [Fact]
    public void XmlStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Xml.ZaabeeSerializer());

    [Fact]
    public void ZeroFormatterStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

    private static void StreamNonGenericTest(IStreamSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.SerializeToStream(type, model);
        var deserializeModel = (TestModel)serializer.DeserializeFromStream(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}