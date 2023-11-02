using Zaabee.Serializer.Types.UnitTest.Models;

namespace Zaabee.Serializer.Types.UnitTest;

public class DateTimeTest
{
#if !NET48
    [Fact]
    public void MemoryPackLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Zaabee.MemoryPack.Serializer());

    [Fact]
    public void MemoryPackUtcTimeTest() =>
        UtcDateTimeToBytesTest(new Zaabee.MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MessagePackUtcTimeTest() =>
        UtcDateTimeToBytesTest(new Zaabee.MessagePack.Serializer());

    [Fact]
    public void MsgPackLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void MsgPackUtcTimeTest() =>
        UtcDateTimeToBytesTest(new Zaabee.MsgPack.Serializer());

    [Fact]
    public void ProtobufLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void ProtobufUtcTimeTest() =>
        UtcDateTimeToBytesTest(new Zaabee.Protobuf.Serializer());

    [Fact]
    public void ZeroFormatterLocalTimeTest() =>
        LocalDateTimeToBytesTest(new Zaabee.ZeroFormatter.Serializer());

    [Fact]
    public void ZeroFormatterUtcTimeTest() =>
        UtcDateTimeToBytesTest(new Zaabee.ZeroFormatter.Serializer());

    [Fact]
    public void JilLocalTimeTest() =>
        LocalDateTimeToTextTest(
            new Zaabee.Jil.Serializer(new Options(dateFormat: DateTimeFormat.ISO8601,
                unspecifiedDateTimeKindBehavior: UnspecifiedDateTimeKindBehavior.IsLocal)));

    [Fact]
    public void JilUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void NewtonsoftJsonUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void NetJsonLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.NetJson.Serializer());

    [Fact]
    public void NetJsonUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.NetJson.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.SpanJson.Serializer());

    [Fact]
    public void SpanJsonUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void SystemTextJsonUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void TomletLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.Tomlet.Serializer());

    [Fact]
    public void TomletUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.Tomlet.Serializer());

    [Fact]
    public void Utf8JsonLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void Utf8JsonUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlSerializerLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void XmlSerializerUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void DataContractSerializerLocalTimeTest() =>
        LocalDateTimeToTextTest(new Zaabee.DataContractSerializer.Serializer());

    [Fact]
    public void DataContractSerializerUtcTimeTest() =>
        UtcDateTimeToTextTest(new Zaabee.DataContractSerializer.Serializer());

    private static void LocalDateTimeToBytesTest(IBytesSerializer bytesSerializer)
    {
        var dateTime = DateTimeModel.Instance(false);
        var dateTimeBytes = bytesSerializer.ToBytes(dateTime);
        var dateTimeResult = bytesSerializer.FromBytes<DateTimeModel>(dateTimeBytes)!;
        Assert.Equal(new DateTimeOffset(dateTime.DateTime), new DateTimeOffset(dateTimeResult.DateTime));
    }

    private static void LocalDateTimeToTextTest(ITextSerializer textSerializer)
    {
        var dateTime = DateTimeModel.Instance(false);
        var dateTimeText = textSerializer.ToText(dateTime);
        var dateTimeResult = textSerializer.FromText<DateTimeModel>(dateTimeText)!;
        Assert.Equal(new DateTimeOffset(dateTime.DateTime), new DateTimeOffset(dateTimeResult.DateTime));
    }

    private static void UtcDateTimeToBytesTest(IBytesSerializer bytesSerializer)
    {
        var dateTime = DateTimeModel.Instance();
        var dateTimeBytes = bytesSerializer.ToBytes(dateTime);
        var dateTimeResult = bytesSerializer.FromBytes<DateTimeModel>(dateTimeBytes)!;
        Assert.Equal(new DateTimeOffset(dateTime.DateTime), new DateTimeOffset(dateTimeResult.DateTime));
    }

    private static void UtcDateTimeToTextTest(ITextSerializer textSerializer)
    {
        var dateTime = DateTimeModel.Instance();
        var dateTimeText = textSerializer.ToText(dateTime);
        var dateTimeResult = textSerializer.FromText<DateTimeModel>(dateTimeText)!;
        Assert.Equal(new DateTimeOffset(dateTime.DateTime), new DateTimeOffset(dateTimeResult.DateTime));
    }
}