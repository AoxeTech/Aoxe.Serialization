namespace Zaabee.SharpYaml;

public sealed class Serializer : IYamlSerializer
{
    public MemoryStream ToStream<TValue>(TValue? value) =>
        SharpYamlHelper.ToStream(value);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        SharpYamlHelper.Pack(value, stream);

    public void Pack(Type type, object? value, Stream? stream) =>
        SharpYamlHelper.Pack(type, value, stream);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SharpYamlHelper.FromStream<TValue>(stream);

    public MemoryStream ToStream(Type type, object? value) =>
        SharpYamlHelper.ToStream(type, value);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SharpYamlHelper.FromStream(type, stream);

    public byte[] ToBytes<TValue>(TValue? value) =>
        SharpYamlHelper.ToBytes(value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SharpYamlHelper.FromBytes<TValue>(bytes);

    public byte[] ToBytes(Type type, object? value) =>
        SharpYamlHelper.ToBytes(type, value);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SharpYamlHelper.FromBytes(type, bytes);

    public string ToText<TValue>(TValue? value) =>
        SharpYamlHelper.ToYaml(value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SharpYamlHelper.FromYaml<TValue>(text);

    public string ToText(Type type, object? value) =>
        SharpYamlHelper.ToYaml(type, value);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SharpYamlHelper.FromYaml(type, text);
}