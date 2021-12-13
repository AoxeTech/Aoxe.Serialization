namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void BinaryStreamNonGenericTest() =>
        StreamNonGenericTest(new Zaabee.Binary.Serializer());

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

    [Fact]
    public void BinaryStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void JilStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void MessagePackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void NewtonsoftJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void SystemTextJsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void ZeroFormatterStreamNonGenericNullTest() =>
        StreamNonGenericNullTest(new Zaabee.ZeroFormatter.Serializer());

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

    private static void StreamNonGenericNullTest(IStreamSerializer serializer)
    {
        var type = typeof(TestModel);
        var stream = serializer.ToStream(type, null);
        Assert.Equal(0, stream.Length);
        var deserializeModel = serializer.FromStream(type, null);
        Assert.Null(deserializeModel);
    }
}