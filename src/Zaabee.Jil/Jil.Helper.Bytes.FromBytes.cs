namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static TValue? FromBytes<TValue>(byte[]? bytes, Options? options = null, Encoding? encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.FromBytes<TValue>(bytes!, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static object? FromBytes(Type type, byte[]? bytes, Options? options = null, Encoding? encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.FromBytes(type, bytes!, encoding ?? DefaultEncoding, options ?? DefaultOptions);
}