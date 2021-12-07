namespace Zaabee.Jil;

public class ZaabeeSerializer : ITextSerializer
{
    private readonly Options? _options;
    private readonly Encoding _encoding;

    public ZaabeeSerializer(Options? options = null, Encoding? encoding = null) =>
        (_options, _encoding) = (options, encoding ?? JilHelper.DefaultEncoding);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : JilSerializer.Serialize(value, _options, _encoding);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : JilSerializer.Serialize(value, _options, _encoding);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.Deserialize<TValue>(bytes!, _options, _encoding);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.Deserialize(type, bytes!, _options, _encoding);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : JilSerializer.SerializeToJson(value, _options);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : JilSerializer.SerializeToJson(value, _options);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.Deserialize<TValue>(text!, _options);

    public object? DeserializeFromString(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.Deserialize(type, text!, _options);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : JilSerializer.Pack(value, _options, _encoding);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : JilSerializer.Pack(value, _options, _encoding);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : JilSerializer.Unpack<TValue>(stream!, _options, _encoding);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : JilSerializer.Unpack(type, stream!, _options, _encoding);
}