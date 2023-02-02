namespace Types.UnitTest;

public class DataTableTest
{
    [Fact]
    [Obsolete("Obsolete")]
    public void BinaryFormatterTest() =>
        DatatableToBytesTest(new Zaabee.Binary.Serializer());

    [Fact]
    public void MessagePackTest() =>
        DatatableToBytesTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackTest() =>
        DatatableToBytesTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void ProtobufTest() =>
        DatatableToBytesTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void ZeroFormatterTest() =>
        DatatableToBytesTest(new Zaabee.ZeroFormatter.Serializer());

    [Fact]
    public void JilTest() =>
        DatatableToTextTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonTest() =>
        DatatableToTextTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonTest() =>
        DatatableToTextTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonTest() =>
        DatatableToTextTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlSerializerTest() =>
        DatatableToTextTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void DataContractSerializerTest() =>
        DatatableToTextTest(new Zaabee.DataContractSerializer.Serializer());

    private static void DatatableToBytesTest(IBytesSerializer bytesSerializer)
    {
        var models = TestModelHelper.Create(100);
        var dt = models.ConvertToDataTable();
        var bytes = bytesSerializer.ToBytes(dt);
        var results = bytesSerializer.FromBytes<DataTable>(bytes)!;
        DataTableHelper.AssertEqual(dt, results);
    }

    private static void DatatableToTextTest(ITextSerializer textSerializer)
    {
        var models = TestModelHelper.Create(100);
        var dt = models.ConvertToDataTable();
        dt.Namespace = "TestModels";
        dt.TableName = "TestModels";
        var text = textSerializer.ToText(dt);
        var results = textSerializer.FromText<DataTable>(text)!;
        DataTableHelper.AssertEqual(dt, results);
    }
}