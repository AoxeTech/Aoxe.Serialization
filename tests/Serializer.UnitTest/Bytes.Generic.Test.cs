namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void BinaryBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Binary.ZaabeeSerializer());

    [Fact]
    public void JilBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Jil.ZaabeeSerializer());

    [Fact]
    public void MessagePackBytesGenericTest() =>
        BytesGenericTest(new Zaabee.MessagePack.ZaabeeSerializer());

    [Fact]
    public void MsgPackBytesGenericTest() =>
        BytesGenericTest(new Zaabee.MsgPack.ZaabeeSerializer());

    [Fact]
    public void NewtonsoftJsonBytesGenericTest() =>
        BytesGenericTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

    [Fact]
    public void ProtobufBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Protobuf.ZaabeeSerializer());

    [Fact]
    public void SystemTextJsonBytesGenericTest() =>
        BytesGenericTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

    [Fact]
    public void Utf8JsonBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Utf8Json.ZaabeeSerializer());

    [Fact]
    public void XmlBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Xml.ZaabeeSerializer());

    [Fact]
    public void ZeroFormatterBytesGenericTest() =>
        BytesGenericTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

    [Fact]
    public void BinaryBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.Binary.ZaabeeSerializer());

    [Fact]
    public void JilBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.Jil.ZaabeeSerializer());

    [Fact]
    public void MessagePackBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.MessagePack.ZaabeeSerializer());

    [Fact]
    public void MsgPackBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.MsgPack.ZaabeeSerializer());

    [Fact]
    public void NewtonsoftJsonBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

    [Fact]
    public void ProtobufBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.Protobuf.ZaabeeSerializer());

    [Fact]
    public void SystemTextJsonBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

    [Fact]
    public void Utf8JsonBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.Utf8Json.ZaabeeSerializer());

    [Fact]
    public void XmlBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.Xml.ZaabeeSerializer());

    [Fact]
    public void ZeroFormatterBytesGenericNullTest() =>
        BytesGenericNullTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

    private static void BytesGenericTest(IBytesSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var bytes = serializer.SerializeToBytes(model);
        var deserializeModel = serializer.DeserializeFromBytes<TestModel>(bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }

    private static void BytesGenericNullTest(IBytesSerializer serializer)
    {
        TestModel? model = null;
        var bytes = serializer.SerializeToBytes(model);
        Assert.Empty(bytes);
        var deserializeModel = serializer.DeserializeFromBytes<TestModel>(null);
        Assert.Null(deserializeModel);
    }
}