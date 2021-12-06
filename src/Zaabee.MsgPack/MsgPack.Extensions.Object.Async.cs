namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue value) => MsgPackHelper.PackAsync(value);

    public static Task PackToAsync<TValue>(this TValue value, Stream? stream) => MsgPackHelper.PackAsync(value, stream);
}