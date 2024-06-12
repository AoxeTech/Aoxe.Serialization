namespace Aoxe.YamlDotNet;

public sealed class Serializer(Encoding? encoding = null) : IYamlSerializer
{
    public void Pack<TValue>(TValue? value, Stream? stream) =>
        YamlDotNetHelper.Pack(value, stream, encoding);

    public void Pack(Type type, object? value, Stream? stream) =>
        YamlDotNetHelper.Pack(value, stream, encoding);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        YamlDotNetHelper.ToStream(value, encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : YamlDotNetHelper.FromStream<TValue>(stream, encoding);

    public MemoryStream ToStream(Type type, object? value) =>
        YamlDotNetHelper.ToStream(value, encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : YamlDotNetHelper.FromStream(type, stream, encoding);

    public byte[] ToBytes<TValue>(TValue? value) => YamlDotNetHelper.ToBytes(value, encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : YamlDotNetHelper.FromBytes<TValue>(bytes, encoding);

    public byte[] ToBytes(Type type, object? value) => YamlDotNetHelper.ToBytes(value, encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : YamlDotNetHelper.FromBytes(type, bytes, encoding);

    public string ToText<TValue>(TValue? value) => YamlDotNetHelper.ToYaml(value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : YamlDotNetHelper.FromYaml<TValue>(text);

    public string ToText(Type type, object? value) => YamlDotNetHelper.ToYaml(value);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : YamlDotNetHelper.FromYaml(type, text);
}
