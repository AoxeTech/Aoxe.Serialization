namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Pack(value, stream, options, encoding);

    public static void PackBy(this Stream? stream, object? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Pack(value, stream, options, encoding);

    public static TValue? Unpack<TValue>(this Stream? stream, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Unpack<TValue>(stream, options, encoding);

    public static object? Unpack(this Stream? stream, Type type, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Unpack(type, stream, options, encoding);
}