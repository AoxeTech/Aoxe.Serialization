namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void DataContractBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.DataContractSerializer.Serializer());

    [Fact]
    public void JilBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void MessagePackBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void ZeroFormatterBytesNonGenericTest() =>
        BytesNonGenericTest(new Zaabee.ZeroFormatter.Serializer());

    private static void BytesNonGenericTest(IBytesSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.ToBytes(type, model);
        var deserializeModel = (TestModel)serializer.FromBytes(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}