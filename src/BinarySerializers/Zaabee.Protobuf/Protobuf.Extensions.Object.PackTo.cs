namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        ProtobufHelper.Pack(value, stream);

    public static void PackTo(this object? value, Stream? stream) =>
        ProtobufHelper.Pack(value, stream);
}
