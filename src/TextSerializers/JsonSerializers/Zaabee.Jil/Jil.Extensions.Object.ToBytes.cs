namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.ToBytes(value, options, encoding);

    public static byte[] ToBytes(
        this object? value,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.ToBytes(value, options, encoding);
}
