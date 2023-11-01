namespace Zaabee.Tomlet;

public class Serializer : ITomlSerializer, IStreamSerializerAsync
{
    private readonly TomlSerializerOptions? _tomlSerializerOptions;
    private readonly Encoding? _encoding;

    public Serializer(TomlSerializerOptions? tomlSerializerOptions = null, Encoding? encoding = null)
    {
        _tomlSerializerOptions = tomlSerializerOptions;
        _encoding = encoding;
    }

    public TValue? FromStream<TValue>(Stream? stream) =>
        TomletHelper.FromStream<TValue>(stream, _tomlSerializerOptions, _encoding);

    public object? FromStream(Type type, Stream? stream) =>
        TomletHelper.FromStream(type, stream, _tomlSerializerOptions, _encoding);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        TomletHelper.Pack(value, stream, _tomlSerializerOptions, _encoding);

    public void Pack(Type type, object? value, Stream? stream) =>
        TomletHelper.Pack(value, stream, _tomlSerializerOptions, _encoding);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        TomletHelper.ToStream(value, _tomlSerializerOptions, _encoding);

    public MemoryStream ToStream(Type type, object? value) =>
        TomletHelper.ToStream(value, _tomlSerializerOptions, _encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        TomletHelper.FromBytes<TValue>(bytes, _tomlSerializerOptions, _encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        TomletHelper.FromBytes(type, bytes, _tomlSerializerOptions, _encoding);

    public byte[] ToBytes<TValue>(TValue? value) =>
        TomletHelper.ToBytes(value, _tomlSerializerOptions, _encoding);

    public byte[] ToBytes(Type type, object? value) =>
        TomletHelper.ToBytes(value, _tomlSerializerOptions, _encoding);

    public TValue? FromText<TValue>(string? text) =>
        TomletHelper.FromToml<TValue>(text, _tomlSerializerOptions);

    public object? FromText(Type type, string? text) =>
        TomletHelper.FromToml(type, text, _tomlSerializerOptions);

    public string ToText<TValue>(TValue? value) =>
        TomletHelper.ToToml(value, _tomlSerializerOptions);

    public string ToText(Type type, object? value) =>
        TomletHelper.ToToml(type, value, _tomlSerializerOptions);

    public ValueTask<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = new CancellationToken()) =>
        TomletHelper.FromStreamAsync<TValue>(stream, _tomlSerializerOptions, _encoding, cancellationToken);

    public ValueTask<object?> FromStreamAsync(Type type, Stream? stream, CancellationToken cancellationToken = new CancellationToken()) =>
        TomletHelper.FromStreamAsync(type, stream, _tomlSerializerOptions, _encoding, cancellationToken);

    public ValueTask PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = new CancellationToken()) =>
        TomletHelper.PackAsync(value, stream, _tomlSerializerOptions, _encoding, cancellationToken);

    public ValueTask PackAsync(Type type, object? value, Stream? stream, CancellationToken cancellationToken = new CancellationToken()) =>
        TomletHelper.PackAsync(value, stream, _tomlSerializerOptions, _encoding, cancellationToken);
}