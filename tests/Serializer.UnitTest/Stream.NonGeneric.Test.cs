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

    [Fact]
    public void BinaryStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Binary.ZaabeeSerializer());

    [Fact]
    public void JilStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Jil.ZaabeeSerializer());

    [Fact]
    public void MessagePackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.MessagePack.ZaabeeSerializer());

    [Fact]
    public void MsgPackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.MsgPack.ZaabeeSerializer());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

    [Fact]
    public void ProtobufStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Protobuf.ZaabeeSerializer());

    [Fact]
    public void SystemTextJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

    [Fact]
    public void Utf8JsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Utf8Json.ZaabeeSerializer());

    [Fact]
    public void XmlStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Xml.ZaabeeSerializer());

    [Fact]
    public void ZeroFormatterStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

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

    private static void StreamNonGenericNullTest(IStreamSerializer serializer)
    {
        var type = typeof(TestModel);
        var stream = serializer.SerializeToStream(type, null);
        Assert.Equal(0, stream.Length);
        var deserializeModel = serializer.DeserializeFromStream(type, null);
        Assert.Null(deserializeModel);
    }
}