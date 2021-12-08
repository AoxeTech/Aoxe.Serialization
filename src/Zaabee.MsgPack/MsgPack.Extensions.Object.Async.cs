namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(this TValue value) =>
        await MsgPackHelper.PackAsync(value);

    public static async Task PackToAsync<TValue>(this TValue value, Stream? stream) =>
        await MsgPackHelper.PackAsync(value, stream);
}