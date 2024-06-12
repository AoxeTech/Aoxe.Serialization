namespace Aoxe.NetJson;

public sealed class Serializer(NetJSONSettings? settings = null)
    : IJsonSerializer,
        IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) => NetJsonHelper.ToBytes(value, settings);

    public byte[] ToBytes(Type type, object? value) => NetJsonHelper.ToBytes(type, value, settings);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : NetJsonHelper.FromBytes<TValue>(bytes, settings);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : NetJsonHelper.FromBytes(type, bytes, settings);

    public string ToText<TValue>(TValue? value) => NetJsonHelper.ToJson(value, settings);

    public string ToText(Type type, object? value) => NetJsonHelper.ToJson(type, value, settings);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : NetJsonHelper.FromJson<TValue>(text, settings);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : NetJsonHelper.FromJson(type, text, settings);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        NetJsonHelper.Pack(value, stream, settings);

    public void Pack(Type type, object? value, Stream? stream) =>
        NetJsonHelper.Pack(type, value, stream, settings);

    public MemoryStream ToStream<TValue>(TValue? value) => NetJsonHelper.ToStream(value, settings);

    public MemoryStream ToStream(Type type, object? value) =>
        NetJsonHelper.ToStream(type, value, settings);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : NetJsonHelper.FromStream<TValue>(stream, settings);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : NetJsonHelper.FromStream(type, stream, settings);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => NetJsonHelper.PackAsync(value, stream, settings);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => NetJsonHelper.PackAsync(type, value, stream, settings);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<TValue?>(default(TValue?))
            : NetJsonHelper.FromStreamAsync<TValue>(stream, settings, cancellationToken);

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<object?>(default(object?))
            : NetJsonHelper.FromStreamAsync(type, stream, settings, cancellationToken);
}
