namespace Zaabee.DataContractSerializer;

public class Serializer : ITextSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : DataContractHelper.ToBytes(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            :  DataContractHelper.ToBytes(type, value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            :  DataContractHelper.FromBytes<TValue>(bytes!);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            :  DataContractHelper.FromBytes(type, bytes!);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            :  DataContractHelper.ToXml(value);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            :  DataContractHelper.ToXml(type, value);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            :  DataContractHelper.FromXml<TValue>(text!);

    public object? DeserializeFromString(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            :  DataContractHelper.FromXml(type, text!);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            :  DataContractHelper.ToStream(value);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            :  DataContractHelper.ToStream(type, value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            :  DataContractHelper.FromStream<TValue>(stream!);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            :  DataContractHelper.FromStream(type, stream!);
}