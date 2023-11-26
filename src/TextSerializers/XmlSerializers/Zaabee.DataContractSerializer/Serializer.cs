namespace Zaabee.DataContractSerializer;

public sealed class Serializer : IXmlSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) => DataContractHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) => DataContractHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0 ? default : DataContractHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0 ? default : DataContractHelper.FromBytes(type, bytes);

    public string ToText<TValue>(TValue? value) => DataContractHelper.ToXml(value);

    public string ToText(Type type, object? value) => DataContractHelper.ToXml(type, value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : DataContractHelper.FromXml<TValue>(text);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : DataContractHelper.FromXml(type, text);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        DataContractHelper.Pack(value, stream);

    public void Pack(Type type, object? value, Stream? stream) =>
        DataContractHelper.Pack(type, value, stream);

    public MemoryStream ToStream<TValue>(TValue? value) => DataContractHelper.ToStream(value);

    public MemoryStream ToStream(Type type, object? value) =>
        DataContractHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : DataContractHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : DataContractHelper.FromStream(type, stream);
}
