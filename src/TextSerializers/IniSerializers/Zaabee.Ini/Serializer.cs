namespace Zaabee.Ini;

public sealed class Serializer : IIniSerializer, IStreamSerializerAsync
{
    private readonly Encoding? _encoding;

    public Serializer(Encoding? encoding = null)
    {
        _encoding = encoding ?? Defaults.Utf8Encoding;
    }

    public byte[] ToBytes<TValue>(TValue? value) =>
        IniParserHelper.ToBytes(value, _encoding);

    public byte[] ToBytes(Type type, object? value) =>
        IniParserHelper.ToBytes(value, _encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : IniParserHelper.FromBytes<TValue>(bytes, _encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : IniParserHelper.FromBytes(type, bytes, _encoding);

    public string ToText<TValue>(TValue? value) =>
        IniParserHelper.ToIni(value);

    public string ToText(Type type, object? value) =>
        IniParserHelper.ToIni(value);

    public TValue? FromText<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : IniParserHelper.FromIni<TValue>(text);

    public object? FromText(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : IniParserHelper.FromIni(type, text);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        IniParserHelper.Pack(value, stream, _encoding);

    public void Pack(Type type, object? value, Stream? stream) =>
        IniParserHelper.Pack(type, value, stream, _encoding);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        IniParserHelper.ToStream(value, _encoding);

    public MemoryStream ToStream(Type type, object? value) =>
        IniParserHelper.ToStream(value, _encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : IniParserHelper.FromStream<TValue>(stream, _encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : IniParserHelper.FromStream(type, stream, _encoding);

    public async Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        await IniParserHelper.PackAsync(value, stream, _encoding, cancellationToken);

    public async Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        await IniParserHelper.PackAsync(value, stream, _encoding, cancellationToken);

    public async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default)
    {
        return stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await IniParserHelper.FromStreamAsync<TValue>(stream, _encoding, cancellationToken);
    }

    public async Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await IniParserHelper.FromStreamAsync(type, stream, _encoding, cancellationToken);
}