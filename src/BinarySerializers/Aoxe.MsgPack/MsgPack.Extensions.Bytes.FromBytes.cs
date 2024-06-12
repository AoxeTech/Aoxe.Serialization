namespace Aoxe.MsgPack;

public static partial class MsgPackExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        MsgPackHelper.FromBytes<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        MsgPackHelper.FromBytes(type, bytes);
}
