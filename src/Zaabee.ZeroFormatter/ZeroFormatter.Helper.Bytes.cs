namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    public static byte[] Serialize<TValue>(TValue value) => value is null ? Array.Empty<byte>() : ZeroSerializer.Serialize(value);

    public static TValue? Deserialize<TValue>(byte[] bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Deserialize<TValue>(bytes);

    public static byte[] Serialize(Type type, object? value) =>
        value is null ? Array.Empty<byte>() : ZeroSerializer.Serialize(type, value);

    public static object? Deserialize(Type type, byte[] bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Deserialize(type, bytes);
}