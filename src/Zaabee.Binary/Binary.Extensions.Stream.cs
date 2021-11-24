namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    public static void PackBy<T>(this Stream? stream, T? t) =>
        BinaryHelper.Pack(t, stream);

    public static T? Unpack<T>(this Stream? stream) =>
        BinaryHelper.Unpack<T>(stream);

    public static object? Unpack(this Stream? stream) =>
        BinaryHelper.Unpack(stream);
}