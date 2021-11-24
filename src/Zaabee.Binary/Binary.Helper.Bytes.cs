namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    public static byte[] Serialize(object? obj) =>
        obj is null ? Array.Empty<byte>() : BinarySerializer.Serialize(obj);

    public static T? Deserialize<T>(byte[]? bytes) =>
        bytes.IsNullOrEmpty() ? default : BinarySerializer.Deserialize<T>(bytes!);

    public static object? Deserialize(byte[]? bytes) =>
        bytes.IsNullOrEmpty() ? null : BinarySerializer.Deserialize(bytes!);
}