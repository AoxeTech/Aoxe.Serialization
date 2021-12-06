namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    public static byte[] Serialize<TValue>(TValue value) =>
        value is null
            ? Array.Empty<byte>()
            : MsgPackSerializer.Serialize(value);

    public static byte[] Serialize(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : MsgPackSerializer.Serialize(type, value);

    public static TValue? Deserialize<TValue>(byte[] bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MsgPackSerializer.Deserialize<TValue>(bytes);

    public static object? Deserialize(Type type, byte[] bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MsgPackSerializer.Deserialize(type, bytes);
}