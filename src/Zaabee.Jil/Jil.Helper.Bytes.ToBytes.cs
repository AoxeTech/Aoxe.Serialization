namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static byte[] ToBytes<TValue>(TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.ToBytes(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static byte[] ToBytes(object? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.ToBytes(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);
}