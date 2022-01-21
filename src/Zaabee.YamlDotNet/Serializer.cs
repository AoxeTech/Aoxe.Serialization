namespace Zaabee.YamlDotNet;

public class Serializer : IYamlSerializer
{
    private readonly Encoding? _encoding;

    public Serializer(Encoding? encoding = null)
    {
        _encoding = encoding;
    }

    public Stream ToStream<TValue>(TValue? value) =>
        YamlDotNetHelper.ToStream(value, _encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : YamlDotNetHelper.FromStream<TValue>(stream, _encoding);

    public Stream ToStream(Type type, object? value) =>
        YamlDotNetHelper.ToStream(value, _encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : YamlDotNetHelper.FromStream(type, stream, _encoding);

    public byte[] ToBytes<TValue>(TValue? value) =>
        YamlDotNetHelper.ToBytes(value, _encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : YamlDotNetHelper.FromBytes<TValue>(bytes, _encoding);

    public byte[] ToBytes(Type type, object? value) =>
        YamlDotNetHelper.ToBytes(value, _encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : YamlDotNetHelper.FromBytes(type, bytes, _encoding);

    public string ToText<TValue>(TValue? value) =>
        YamlDotNetHelper.ToYaml(value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : YamlDotNetHelper.FromYaml<TValue>(text);

    public string ToText(Type type, object? value) =>
        YamlDotNetHelper.ToYaml(value);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : YamlDotNetHelper.FromYaml(type, text);

    public string ToYaml<TValue>(TValue? value) =>
        YamlDotNetHelper.ToYaml(value);

    public TValue? FromYaml<TValue>(string? yaml) =>
        string.IsNullOrWhiteSpace(yaml)
            ? default
            : YamlDotNetHelper.FromYaml<TValue>(yaml);

    public string ToYaml(Type type, object? value) =>
        YamlDotNetHelper.ToYaml(value);

    public object? FromYaml(Type type, string? yaml) =>
        string.IsNullOrWhiteSpace(yaml)
            ? default
            : YamlDotNetHelper.FromYaml(type, yaml);
}