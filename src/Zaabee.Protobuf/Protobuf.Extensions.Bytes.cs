namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static TValue? FromBytes<TValue>(this byte[] bytes) => ProtobufHelper.Deserialize<TValue>(bytes);

    public static object? FromBytes(this byte[] bytes, Type type) => ProtobufHelper.Deserialize(type, bytes);
}