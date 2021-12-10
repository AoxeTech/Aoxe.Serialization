namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value) =>
        MsgPackHelper.PackAsync(value, stream);
}