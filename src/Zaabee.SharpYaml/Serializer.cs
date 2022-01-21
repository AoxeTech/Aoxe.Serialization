namespace Zaabee.SharpYaml;

public class Serializer : IYamlSerializer
{
    public Stream ToStream<TValue>(TValue? value) =>
        SharpYamlHelper.ToStream(value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : SharpYamlHelper.FromStream<TValue>(stream);

    public Stream ToStream(Type type, object? value) =>
        SharpYamlHelper.ToStream(type, value);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
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

    public string ToYaml<TValue>(TValue? value) =>
        SharpYamlHelper.ToYaml(value);

    public TValue? FromYaml<TValue>(string? yaml) =>
        string.IsNullOrWhiteSpace(yaml)
            ? default
            : SharpYamlHelper.FromYaml<TValue>(yaml);

    public string ToYaml(Type type, object? value) =>
        SharpYamlHelper.ToYaml(type, value);

    public object? FromYaml(Type type, string? yaml) =>
        string.IsNullOrWhiteSpace(yaml)
            ? default
            : SharpYamlHelper.FromYaml(type, yaml);
}