namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task<byte[]> ToBytesAsync<TValue>(this TValue? value) =>
        MsgPackHelper.ToBytesAsync(value);
}