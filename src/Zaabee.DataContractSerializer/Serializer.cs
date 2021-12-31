namespace Zaabee.DataContractSerializer;

public class Serializer : ITextSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : DataContractHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : DataContractHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : DataContractHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : DataContractHelper.FromBytes(type, bytes);

    public string ToText<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : DataContractHelper.ToXml(value);

    public string ToText(Type type, object? value) =>
        value is null
            ? string.Empty
            : DataContractHelper.ToXml(type, value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : DataContractHelper.FromXml<TValue>(text);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : DataContractHelper.FromXml(type, text);

    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : DataContractHelper.ToStream(value);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : DataContractHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : DataContractHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : DataContractHelper.FromStream(type, stream);
}