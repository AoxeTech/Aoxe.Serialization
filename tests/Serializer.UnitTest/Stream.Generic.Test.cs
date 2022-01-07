namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact, Obsolete]
    public void BinaryStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void DataContractStreamGenericTest() =>
        StreamGenericTest(new Zaabee.DataContractSerializer.Serializer());

    [Fact]
    public void JilStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void MessagePackStreamGenericTest() =>
        StreamGenericTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamGenericTest() =>
        StreamGenericTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamGenericTest() =>
        StreamGenericTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonStreamGenericTest() =>
        StreamGenericTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStreamGenericTest() =>
        StreamGenericTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void ZeroFormatterStreamGenericTest() =>
        StreamGenericTest(new Zaabee.ZeroFormatter.Serializer());

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