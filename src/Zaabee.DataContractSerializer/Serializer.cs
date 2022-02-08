namespace Zaabee.DataContractSerializer;

public class Serializer : IXmlSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        DataContractHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        DataContractHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : DataContractHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : DataContractHelper.FromBytes(type, bytes);

    public string ToText<TValue>(TValue? value) =>
        DataContractHelper.ToXml(value);

    public string ToText(Type type, object? value) =>
        DataContractHelper.ToXml(type, value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : DataContractHelper.FromXml<TValue>(text);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : DataContractHelper.FromXml(type, text);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        DataContractHelper.ToStream(value);

    public MemoryStream ToStream(Type type, object? value) =>
        DataContractHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : DataContractHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : DataContractHelper.FromStream(type, stream);

    public string ToXml<TValue>(TValue? value) =>
        ToText(value);

    public TValue? FromXml<TValue>(string? xml) =>
        FromText<TValue>(xml);

    public string ToXml(Type type, object? value) =>
        ToText(type, value);

    public object? FromXml(Type type, string? xml) =>
        FromText(type, xml);
}