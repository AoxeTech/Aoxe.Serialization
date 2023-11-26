namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.FromStream<TValue>(stream, options, encoding);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.FromStream(type, stream, options, encoding);
}
