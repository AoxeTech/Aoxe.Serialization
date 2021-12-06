namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static TValue? FromBytes<TValue>(this byte[] bytes, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Deserialize<TValue>(bytes, options, encoding);

    public static object? FromBytes(this byte[] bytes, Type type, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Deserialize(type, bytes, options, encoding);
}