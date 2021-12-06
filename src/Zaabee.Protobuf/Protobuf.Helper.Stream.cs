namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    public static Stream Pack<TValue>(TValue value) =>
        value is null
            ? Stream.Null
            : ProtobufSerializer.Pack(value);

    public static Stream Pack(object? value) =>
        value is null
            ? Stream.Null
            : ProtobufSerializer.Pack(value);

    public static void Pack<TValue>(TValue value, Stream? stream)
    {
        if (value is not null && stream is not null)
            ProtobufSerializer.Pack(value, stream);
    }

    public static void Pack(object? value, Stream? stream)
    {
        if (value is not null && stream is not null)
            ProtobufSerializer.Pack(value, stream);
    }

    public static TValue? Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Unpack<TValue>(stream);

    public static object? Unpack(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Unpack(type, stream);
}