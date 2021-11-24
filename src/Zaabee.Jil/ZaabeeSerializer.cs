namespace Zaabee.Jil;

public class ZaabeeSerializer : ITextSerializer
{
    private readonly Options? _options;
    private readonly Encoding _encoding;

    public ZaabeeSerializer(Options? options = null, Encoding? encoding = null) =>
        (_options, _encoding) = (options, encoding ?? JilHelper.DefaultEncoding);

    public byte[] SerializeToBytes<T>(T? value) =>
        value is null
            ? Array.Empty<byte>()
            : JilSerializer.Serialize(value, _options, _encoding);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : JilSerializer.Serialize(value, _options, _encoding);

    public T? DeserializeFromBytes<T>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? (T?)typeof(T).GetDefaultValue()
            : JilSerializer.Deserialize<T>(bytes!, _options, _encoding);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : JilSerializer.Deserialize(type, bytes!, _options, _encoding);

    public string SerializeToString<T>(T? value) =>
        value is null
            ? string.Empty
            : JilSerializer.SerializeToJson(value, _options);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : JilSerializer.SerializeToJson(value, _options);

    public T? DeserializeFromString<T>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? (T?)typeof(T).GetDefaultValue()
            : JilSerializer.Deserialize<T>(text!, _options);

    public object? DeserializeFromString(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? type.GetDefaultValue()
            : JilSerializer.Deserialize(type, text!, _options);

    public Stream SerializeToStream<T>(T? value) =>
        value is null
            ? new MemoryStream()
            : JilSerializer.Pack(value, _options, _encoding);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? new MemoryStream()
            : JilSerializer.Pack(value, _options, _encoding);

    public T? DeserializeFromStream<T>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? (T?)typeof(T).GetDefaultValue()
            : JilSerializer.Unpack<T>(stream!, _options, _encoding);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : JilSerializer.Unpack(type, stream!, _options, _encoding);
}