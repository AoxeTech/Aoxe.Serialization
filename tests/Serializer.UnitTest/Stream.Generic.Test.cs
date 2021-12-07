namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void BinaryStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Binary.ZaabeeSerializer());

    [Fact]
    public void JilStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Jil.ZaabeeSerializer());

    [Fact]
    public void MessagePackStreamGenericTest() =>
        StreamGenericTest(new Zaabee.MessagePack.ZaabeeSerializer());

    [Fact]
    public void MsgPackStreamGenericTest() =>
        StreamGenericTest(new Zaabee.MsgPack.ZaabeeSerializer());

    [Fact]
    public void NewtonsoftJsonStreamGenericTest() =>
        StreamGenericTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

    [Fact]
    public void ProtobufStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Protobuf.ZaabeeSerializer());

    [Fact]
    public void SystemTextJsonStreamGenericTest() =>
        StreamGenericTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

    [Fact]
    public void Utf8JsonStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Utf8Json.ZaabeeSerializer());

    [Fact]
    public void XmlStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Xml.ZaabeeSerializer());

    [Fact]
    public void ZeroFormatterStreamGenericTest() =>
        StreamGenericTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

    [Fact]
    public void BinaryStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Binary.ZaabeeSerializer());

    [Fact]
    public void JilStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Jil.ZaabeeSerializer());

    [Fact]
    public void MessagePackStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.MessagePack.ZaabeeSerializer());

    [Fact]
    public void MsgPackStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.MsgPack.ZaabeeSerializer());

    [Fact]
    public void NewtonsoftJsonStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

    [Fact]
    public void ProtobufStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Protobuf.ZaabeeSerializer());

    [Fact]
    public void SystemTextJsonStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

    [Fact]
    public void Utf8JsonStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Utf8Json.ZaabeeSerializer());

    [Fact]
    public void XmlStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.Xml.ZaabeeSerializer());

    [Fact]
    public void ZeroFormatterStreamGenericNullTest() =>
        StreamGenericNullTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

    private static void StreamGenericTest(IStreamSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var stream = serializer.SerializeToStream(model);
        var deserializeModel = serializer.DeserializeFromStream<TestModel>(stream)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }

    private static void StreamGenericNullTest(IStreamSerializer serializer)
    {
        TestModel? model = null;
        var stream = serializer.SerializeToStream(model);
        Assert.Equal(0, stream.Length);
        var deserializeModel = serializer.DeserializeFromStream<TestModel>(null);
        Assert.Null(deserializeModel);
    }
}