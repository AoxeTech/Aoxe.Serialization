namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static async Task PackByAsync<TValue>(this Stream? stream, TValue value) =>
        await MsgPackHelper.PackAsync(value, stream);

    public static async Task<TValue?> UnpackAsync<TValue>(this Stream? stream) =>
        await MsgPackHelper.UnpackAsync<TValue>(stream);
}