namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void BinaryBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Binary.ZaabeeSerializer());

    [Fact]
    public void JilBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Jil.ZaabeeSerializer());

    [Fact]
    public void MessagePackBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.MessagePack.ZaabeeSerializer());

    [Fact]
    public void MsgPackBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.MsgPack.ZaabeeSerializer());

    [Fact]
    public void NewtonsoftJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

    [Fact]
    public void ProtobufBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Protobuf.ZaabeeSerializer());

    [Fact]
    public void SystemTextJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

    [Fact]
    public void Utf8JsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Utf8Json.ZaabeeSerializer());

    [Fact]
    public void XmlBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Xml.ZaabeeSerializer());

    [Fact]
    public void ZeroFormatterBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

    private static void BytesNonGenericTest(IBytesSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.SerializeToBytes(type, model);
        var deserializeModel = (TestModel)serializer.DeserializeFromBytes(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}