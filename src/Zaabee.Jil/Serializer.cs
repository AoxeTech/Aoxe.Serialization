namespace Zaabee.Jil;

public class Serializer : IJsonSerializer
{
    private readonly Options? _options;
    private readonly Encoding? _encoding;

    public Serializer(Options? options = null, Encoding? encoding = null) =>
        (_options, _encoding) = (options, encoding);

    public byte[] ToBytes<TValue>(TValue? value) =>
        JilHelper.ToBytes(value, _options, _encoding);

    public byte[] ToBytes(Type type, object? value) =>
        JilHelper.ToBytes(value, _options, _encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : JilHelper.FromBytes<TValue>(bytes, _options, _encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : JilHelper.FromBytes(type, bytes, _options, _encoding);

    public string ToText<TValue>(TValue? value) =>
        JilHelper.ToJson(value, _options);

    public string ToText(Type type, object? value) =>
        JilHelper.ToJson(value, _options);

    public TValue? FromText<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilHelper.FromJson<TValue>(text, _options);

    public object? FromText(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : JilHelper.FromJson(type, text, _options);

    public Stream ToStream<TValue>(TValue? value) =>
        JilHelper.ToStream(value, _options, _encoding);

    public Stream ToStream(Type type, object? value) =>
        JilHelper.ToStream(value, _options, _encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : JilHelper.FromStream<TValue>(stream, _options, _encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : JilHelper.FromStream(type, stream, _options, _encoding);

    public string ToJson<TValue>(TValue? value) =>
        JilHelper.ToJson(value, _options);

    public TValue? FromJson<TValue>(string? json) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JilHelper.FromJson<TValue>(json, _options);

    public string ToJson(Type type, object? value) =>
        JilHelper.ToJson(value, _options);

    public object? FromJson(Type type, string? json) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JilHelper.FromJson(type, json, _options);
}