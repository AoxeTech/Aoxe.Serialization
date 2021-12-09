namespace Zaabee.Jil;

public class Serializer : ITextSerializer
{
    private readonly Options? _options;
    private readonly Encoding? _encoding;

    public Serializer(Options? options = null, Encoding? encoding = null) =>
        (_options, _encoding) = (options, encoding);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : JilHelper.ToBytes(value, _options, _encoding);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : JilHelper.ToBytes(value, _options, _encoding);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilHelper.FromBytes<TValue>(bytes!, _options, _encoding);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilHelper.FromBytes(type, bytes!, _options, _encoding);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : JilHelper.ToJson(value, _options);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : JilHelper.ToJson(value, _options);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilHelper.FromJson<TValue>(text!, _options);

    public object? DeserializeFromString(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilHelper.FromJson(type, text!, _options);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : JilHelper.ToStream(value, _options, _encoding);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : JilHelper.ToStream(value, _options, _encoding);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : JilHelper.FromStream<TValue>(stream!, _options, _encoding);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : JilHelper.FromStream(type, stream!, _options, _encoding);
}