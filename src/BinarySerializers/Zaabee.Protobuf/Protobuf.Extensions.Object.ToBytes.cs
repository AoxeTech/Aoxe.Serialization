namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) =>
        ProtobufHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value) =>
        ProtobufHelper.ToBytes(value);
}