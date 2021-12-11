namespace Zaabee.MsgPack;

public class Serializer : IBytesSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : MsgPackHelper.ToBytes(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : MsgPackHelper.ToBytes(type, value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MsgPackHelper.FromBytes<TValue>(bytes!);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MsgPackHelper.FromBytes(type, bytes!);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : MsgPackHelper.ToStream(value);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : MsgPackHelper.ToStream(type, value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MsgPackHelper.FromStream<TValue>(stream!);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MsgPackHelper.FromStream(type, stream!);
}