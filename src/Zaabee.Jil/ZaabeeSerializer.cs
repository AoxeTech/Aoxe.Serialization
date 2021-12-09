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
            : JilSerializer.ToBytes(value, _encoding, _options);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : JilSerializer.ToBytes(value, _encoding, _options);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.FromBytes<TValue>(bytes!, _encoding, _options);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.FromBytes(type, bytes!, _encoding, _options);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : JilSerializer.ToJson(value, _options);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : JilSerializer.ToJson(value, _options);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.FromJson<TValue>(text!, _options);

    public object? DeserializeFromString(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.FromJson(type, text!, _options);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : JilSerializer.ToStream(value, _encoding, _options);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : JilSerializer.ToStream(value, _encoding, _options);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : JilSerializer.FromStream<TValue>(stream!, _encoding, _options);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : JilSerializer.FromStream(type, stream!, _encoding, _options);
}