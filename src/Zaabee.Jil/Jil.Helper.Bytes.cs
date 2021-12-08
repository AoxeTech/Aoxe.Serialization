namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static byte[] Serialize<TValue>(TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.Serialize(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static byte[] Serialize(object? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.Serialize(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static TValue? Deserialize<TValue>(byte[] bytes, Options? options = null, Encoding? encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.Deserialize<TValue>(bytes, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static object? Deserialize(Type type, byte[] bytes, Options? options = null, Encoding? encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.Deserialize(type, bytes, encoding ?? DefaultEncoding, options ?? DefaultOptions);
}