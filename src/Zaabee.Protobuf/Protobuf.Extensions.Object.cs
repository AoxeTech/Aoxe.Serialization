namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static byte[] ToBytes<TValue>(this TValue value) => ProtobufHelper.Serialize(value);

    public static byte[] ToBytes(this object? value) => ProtobufHelper.Serialize(value);

    public static Stream ToStream<TValue>(this TValue value) => ProtobufHelper.Pack(value);

    public static Stream ToStream(this object? value) => ProtobufHelper.Pack(value);

    public static void PackTo<TValue>(this TValue value, Stream? stream) => ProtobufHelper.Pack(value, stream);

    public static void PackTo(this object? value, Stream? stream) => ProtobufHelper.Pack(value, stream);
}