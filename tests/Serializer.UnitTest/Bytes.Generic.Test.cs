namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void DataContractBytesGenericTest() =>
        BytesGenericTest(new Zaabee.DataContractSerializer.Serializer());

    [Fact]
    public void JilBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void MessagePackBytesGenericTest() =>
        BytesGenericTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackBytesGenericTest() =>
        BytesGenericTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonBytesGenericTest() =>
        BytesGenericTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonBytesGenericTest() =>
        BytesGenericTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlBytesGenericTest() =>
        BytesGenericTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void ZeroFormatterBytesGenericTest() =>
        BytesGenericTest(new Zaabee.ZeroFormatter.Serializer());

    private static void BytesGenericTest(IBytesSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var bytes = serializer.ToBytes(model);
        var deserializeModel = serializer.FromBytes<TestModel>(bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}