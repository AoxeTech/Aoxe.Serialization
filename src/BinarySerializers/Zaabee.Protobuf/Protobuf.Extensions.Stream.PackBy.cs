namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        ProtobufHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, object? value) =>
        ProtobufHelper.Pack(value, stream);
}