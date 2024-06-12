namespace Aoxe.Protobuf;

public static partial class ProtobufExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        ProtobufHelper.FromBytes<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        ProtobufHelper.FromBytes(type, bytes);
}
