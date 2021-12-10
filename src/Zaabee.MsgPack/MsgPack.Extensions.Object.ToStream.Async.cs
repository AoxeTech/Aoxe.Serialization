namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value) =>
        await MsgPackHelper.ToStreamAsync(value);
}