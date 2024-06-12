namespace Aoxe.Serializer.Types.UnitTest;

public class DateTimeTest
{
#if !NET48
    [Fact]
    public void MemoryPackLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Aoxe.MemoryPack.Serializer());

    [Fact]
    public void MemoryPackUtcTimeTest() => UtcDateTimeToBytesTest(new Aoxe.MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Aoxe.MessagePack.Serializer());

    [Fact]
    public void MessagePackUtcTimeTest() =>
        UtcDateTimeToBytesTest(new Aoxe.MessagePack.Serializer());

    [Fact]
    public void MsgPackLocalTimeTest() => LocalDateTimeToBytesTest(new Aoxe.MsgPack.Serializer());

    [Fact]
    public void MsgPackUtcTimeTest() => UtcDateTimeToBytesTest(new Aoxe.MsgPack.Serializer());

    [Fact]
    public void ProtobufLocalTimeTest() => LocalDateTimeToBytesTest(new Aoxe.Protobuf.Serializer());

    [Fact]
    public void ProtobufUtcTimeTest() => UtcDateTimeToBytesTest(new Aoxe.Protobuf.Serializer());

    [Fact]
    public void ZeroFormatterLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Aoxe.ZeroFormatter.Serializer());

    [Fact]
    public void ZeroFormatterUtcTimeTest() =>
        UtcDateTimeToBytesTest(new Aoxe.ZeroFormatter.Serializer());

    [Fact]
    public void JilLocalTimeTest() =>
        LocalDateTimeToTextTest(
            new Aoxe.Jil.Serializer(
                new Options(
                    dateFormat: DateTimeFormat.ISO8601,
                    unspecifiedDateTimeKindBehavior: UnspecifiedDateTimeKindBehavior.IsLocal
                )
            )
        );

    [Fact]
    public void JilUtcTimeTest() => UtcDateTimeToTextTest(new Aoxe.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonLocalTimeTest() =>
        LocalDateTimeToTextTest(new Aoxe.NewtonsoftJson.Serializer());

    [Fact]
    public void NewtonsoftJsonUtcTimeTest() =>
        UtcDateTimeToTextTest(new Aoxe.NewtonsoftJson.Serializer());

    [Fact]
    public void NetJsonLocalTimeTest() => LocalDateTimeToTextTest(new Aoxe.NetJson.Serializer());

    [Fact]
    public void NetJsonUtcTimeTest() => UtcDateTimeToTextTest(new Aoxe.NetJson.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonLocalTimeTest() => LocalDateTimeToTextTest(new Aoxe.SpanJson.Serializer());

    [Fact]
    public void SpanJsonUtcTimeTest() => UtcDateTimeToTextTest(new Aoxe.SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonLocalTimeTest() =>
        LocalDateTimeToTextTest(new Aoxe.SystemTextJson.Serializer());

    [Fact]
    public void SystemTextJsonUtcTimeTest() =>
        UtcDateTimeToTextTest(new Aoxe.SystemTextJson.Serializer());

    [Fact]
    public void TomletLocalTimeTest() => LocalDateTimeToTextTest(new Aoxe.Tomlet.Serializer());

    [Fact]
    public void TomletUtcTimeTest() => UtcDateTimeToTextTest(new Aoxe.Tomlet.Serializer());

    [Fact]
    public void Utf8JsonLocalTimeTest() => LocalDateTimeToTextTest(new Aoxe.Utf8Json.Serializer());

    [Fact]
    public void Utf8JsonUtcTimeTest() => UtcDateTimeToTextTest(new Aoxe.Utf8Json.Serializer());

    [Fact]
    public void XmlSerializerLocalTimeTest() => LocalDateTimeToTextTest(new Aoxe.Xml.Serializer());

    [Fact]
    public void XmlSerializerUtcTimeTest() => UtcDateTimeToTextTest(new Aoxe.Xml.Serializer());

    [Fact]
    public void DataContractSerializerLocalTimeTest() =>
        LocalDateTimeToTextTest(new Aoxe.DataContractSerializer.Serializer());

    [Fact]
    public void DataContractSerializerUtcTimeTest() =>
        UtcDateTimeToTextTest(new Aoxe.DataContractSerializer.Serializer());

    private static void LocalDateTimeToBytesTest(IBytesSerializer bytesSerializer)
    {
        var dateTime = DateTimeModel.Instance(false);
        var dateTimeBytes = bytesSerializer.ToBytes(dateTime);
        var dateTimeResult = bytesSerializer.FromBytes<DateTimeModel>(dateTimeBytes)!;
        Assert.Equal(
            new DateTimeOffset(dateTime.DateTime),
            new DateTimeOffset(dateTimeResult.DateTime)
        );
    }

    private static void LocalDateTimeToTextTest(ITextSerializer textSerializer)
    {
        var dateTime = DateTimeModel.Instance(false);
        var dateTimeText = textSerializer.ToText(dateTime);
        var dateTimeResult = textSerializer.FromText<DateTimeModel>(dateTimeText)!;
        Assert.Equal(
            new DateTimeOffset(dateTime.DateTime),
            new DateTimeOffset(dateTimeResult.DateTime)
        );
    }

    private static void UtcDateTimeToBytesTest(IBytesSerializer bytesSerializer)
    {
        var dateTime = DateTimeModel.Instance();
        var dateTimeBytes = bytesSerializer.ToBytes(dateTime);
        var dateTimeResult = bytesSerializer.FromBytes<DateTimeModel>(dateTimeBytes)!;
        Assert.Equal(
            new DateTimeOffset(dateTime.DateTime),
            new DateTimeOffset(dateTimeResult.DateTime)
        );
    }

    private static void UtcDateTimeToTextTest(ITextSerializer textSerializer)
    {
        var dateTime = DateTimeModel.Instance();
        var dateTimeText = textSerializer.ToText(dateTime);
        var dateTimeResult = textSerializer.FromText<DateTimeModel>(dateTimeText)!;
        Assert.Equal(
            new DateTimeOffset(dateTime.DateTime),
            new DateTimeOffset(dateTimeResult.DateTime)
        );
    }
}
