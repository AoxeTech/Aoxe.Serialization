namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static async Task<TValue?> FromStreamAsync<TValue>(this Stream? stream) =>
        await MsgPackHelper.FromStreamAsync<TValue>(stream);
}