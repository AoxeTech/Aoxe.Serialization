namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static byte[] Serialize<TValue>(TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.Serialize(value, options ?? DefaultOptions, encoding ?? DefaultEncoding);

    public static byte[] Serialize(object? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.Serialize(value, options ?? DefaultOptions, encoding ?? DefaultEncoding);

    public static TValue? Deserialize<TValue>(byte[] bytes, Options? options = null, Encoding? encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.Deserialize<TValue>(bytes, options ?? DefaultOptions, encoding ?? DefaultEncoding);

    public static object? Deserialize(Type type, byte[] bytes, Options? options = null, Encoding? encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : JilSerializer.Deserialize(type, bytes, options ?? DefaultOptions, encoding ?? DefaultEncoding);
}