namespace Aoxe.MsgPack;

public static partial class MsgPackExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        MsgPackHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        MsgPackHelper.FromStream(type, stream);
}
