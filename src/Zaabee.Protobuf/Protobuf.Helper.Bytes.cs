namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    public static byte[] Serialize<TValue>(TValue value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufSerializer.Serialize(value);

    public static byte[] Serialize(object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufSerializer.Serialize(value);

    public static TValue? Deserialize<TValue>(byte[] bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Deserialize<TValue>(bytes);

    public static object? Deserialize(Type type, byte[] bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Deserialize(type, bytes);
}