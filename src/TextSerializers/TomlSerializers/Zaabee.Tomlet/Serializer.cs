namespace Zaabee.Tomlet;

public class Serializer(
    TomlSerializerOptions? tomlSerializerOptions = null,
    Encoding? encoding = null
) : ITomlSerializer, IStreamSerializerAsync
{
    public TValue? FromStream<TValue>(Stream? stream) =>
        TomletHelper.FromStream<TValue>(stream, tomlSerializerOptions, encoding);

    public object? FromStream(Type type, Stream? stream) =>
        TomletHelper.FromStream(type, stream, tomlSerializerOptions, encoding);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        TomletHelper.Pack(value, stream, tomlSerializerOptions, encoding);

    public void Pack(Type type, object? value, Stream? stream) =>
        TomletHelper.Pack(value, stream, tomlSerializerOptions, encoding);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        TomletHelper.ToStream(value, tomlSerializerOptions, encoding);

    public MemoryStream ToStream(Type type, object? value) =>
        TomletHelper.ToStream(value, tomlSerializerOptions, encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        TomletHelper.FromBytes<TValue>(bytes, tomlSerializerOptions, encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        TomletHelper.FromBytes(type, bytes, tomlSerializerOptions, encoding);

    public byte[] ToBytes<TValue>(TValue? value) =>
        TomletHelper.ToBytes(value, tomlSerializerOptions, encoding);

    public byte[] ToBytes(Type type, object? value) =>
        TomletHelper.ToBytes(value, tomlSerializerOptions, encoding);

    public TValue? FromText<TValue>(string? text) =>
        TomletHelper.FromToml<TValue>(text, tomlSerializerOptions);

    public object? FromText(Type type, string? text) =>
        TomletHelper.FromToml(type, text, tomlSerializerOptions);

    public string ToText<TValue>(TValue? value) =>
        TomletHelper.ToToml(value, tomlSerializerOptions);

    public string ToText(Type type, object? value) =>
        TomletHelper.ToToml(type, value, tomlSerializerOptions);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = new CancellationToken()
    ) =>
        TomletHelper.FromStreamAsync<TValue>(
            stream,
            tomlSerializerOptions,
            encoding,
            cancellationToken
        );

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = new CancellationToken()
    ) =>
        TomletHelper.FromStreamAsync(
            type,
            stream,
            tomlSerializerOptions,
            encoding,
            cancellationToken
        );

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = new CancellationToken()
    ) => TomletHelper.PackAsync(value, stream, tomlSerializerOptions, encoding, cancellationToken);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = new CancellationToken()
    ) => TomletHelper.PackAsync(value, stream, tomlSerializerOptions, encoding, cancellationToken);
}
