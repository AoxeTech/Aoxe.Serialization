namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) =>
        MsgPackHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        MsgPackHelper.ToBytes(type, value);
}