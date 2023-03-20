using Jil;

namespace Types.UnitTest;

public class DateTimeTest
{
    private readonly DateTime _localTime = new(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);
    private readonly DateTime _utcTime = new(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    [Fact]
    [Obsolete("Obsolete")]
    public void BinaryFormatterLocalTimeTest() =>
        DateTimeToBytesTest(new Zaabee.Binary.Serializer(), _localTime);

    [Fact]
    [Obsolete("Obsolete")]
    public void BinaryFormatterUtcTimeTest() =>
        DateTimeToBytesTest(new Zaabee.Binary.Serializer(), _utcTime);

    [Fact]
    public void MessagePackLocalTimeTest() =>
        DateTimeToBytesTest(new Zaabee.MessagePack.Serializer(), _localTime);

    [Fact]
    public void MessagePackUtcTimeTest() =>
        DateTimeToBytesTest(new Zaabee.MessagePack.Serializer(), _utcTime);

    [Fact]
    public void MsgPackLocalTimeTest() =>
        DateTimeToBytesTest(new Zaabee.MsgPack.Serializer(), _localTime);

    [Fact]
    public void MsgPackUtcTimeTest() =>
        DateTimeToBytesTest(new Zaabee.MsgPack.Serializer(), _utcTime);

    [Fact]
    public void ProtobufLocalTimeTest() =>
        DateTimeToBytesTest(new Zaabee.Protobuf.Serializer(), _localTime);

    [Fact]
    public void ProtobufUtcTimeTest() =>
        DateTimeToBytesTest(new Zaabee.Protobuf.Serializer(), _utcTime);

    [Fact]
    public void ZeroFormatterLocalTimeTest() =>
        DateTimeToBytesTest(new Zaabee.ZeroFormatter.Serializer(), _localTime);

    [Fact]
    public void ZeroFormatterUtcTimeTest() =>
        DateTimeToBytesTest(new Zaabee.ZeroFormatter.Serializer(), _utcTime);

    [Fact]
    public void JilLocalTimeTest() =>
        DateTimeToTextTest(
            new Zaabee.Jil.Serializer(new Options(dateFormat: DateTimeFormat.ISO8601,
                unspecifiedDateTimeKindBehavior: UnspecifiedDateTimeKindBehavior.IsLocal)), _localTime);

    [Fact]
    public void JilUtcTimeTest() =>
        DateTimeToTextTest(new Zaabee.Jil.Serializer(), _utcTime);

    [Fact]
    public void NewtonsoftJsonLocalTimeTest() =>
        DateTimeToTextTest(new Zaabee.NewtonsoftJson.Serializer(), _localTime);

    [Fact]
    public void NewtonsoftJsonUtcTimeTest() =>
        DateTimeToTextTest(new Zaabee.NewtonsoftJson.Serializer(), _utcTime);

    [Fact]
    public void SystemTextJsonLocalTimeTest() =>
        DateTimeToTextTest(new Zaabee.SystemTextJson.Serializer(), _localTime);

    [Fact]
    public void SystemTextJsonUtcTimeTest() =>
        DateTimeToTextTest(new Zaabee.SystemTextJson.Serializer(), _utcTime);

    [Fact]
    public void Utf8JsonLocalTimeTest() =>
        DateTimeToTextTest(new Zaabee.Utf8Json.Serializer(), _localTime);

    [Fact]
    public void Utf8JsonUtcTimeTest() =>
        DateTimeToTextTest(new Zaabee.Utf8Json.Serializer(), _utcTime);

    [Fact]
    public void XmlSerializerLocalTimeTest() =>
        DateTimeToTextTest(new Zaabee.Xml.Serializer(), _localTime);

    [Fact]
    public void XmlSerializerUtcTimeTest() =>
        DateTimeToTextTest(new Zaabee.Xml.Serializer(), _utcTime);

    [Fact]
    public void DataContractSerializerLocalTimeTest() =>
        DateTimeToTextTest(new Zaabee.DataContractSerializer.Serializer(), _localTime);

    [Fact]
    public void DataContractSerializerUtcTimeTest() =>
        DateTimeToTextTest(new Zaabee.DataContractSerializer.Serializer(), _utcTime);

    private static void DateTimeToBytesTest(IBytesSerializer bytesSerializer, DateTime dateTime)
    {
        var dateTimeBytes = bytesSerializer.ToBytes(dateTime);
        var dateTimeResult = bytesSerializer.FromBytes<DateTime>(dateTimeBytes)!;
        Assert.Equal(new DateTimeOffset(dateTime), new DateTimeOffset(dateTimeResult));
    }

    private static void DateTimeToTextTest(ITextSerializer textSerializer, DateTime dateTime)
    {
        var dateTimeText = textSerializer.ToText(dateTime);
        var dateTimeResult = textSerializer.FromText<DateTime>(dateTimeText)!;
        Assert.Equal(new DateTimeOffset(dateTime), new DateTimeOffset(dateTimeResult));
    }
}