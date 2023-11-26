namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        ProtobufHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        ProtobufHelper.FromStream(type, stream);
}
