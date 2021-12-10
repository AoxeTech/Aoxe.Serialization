namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream) =>
        MsgPackHelper.FromStreamAsync<TValue>(stream);
}