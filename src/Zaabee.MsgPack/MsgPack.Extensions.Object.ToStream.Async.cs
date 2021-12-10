namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value) =>
        MsgPackHelper.ToStreamAsync(value);
}