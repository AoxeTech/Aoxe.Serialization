namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static Stream Pack<TValue>(TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.Pack(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static void Pack<TValue>(TValue? value, Stream? stream, Options? options = null, Encoding? encoding = null)
    {
        if (stream is null) return;
        JilSerializer.Pack(value, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions);
    }

    public static Stream Pack(object? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.Pack(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static void Pack(object? value, Stream? stream, Options? options = null, Encoding? encoding = null)
    {
        if (stream is null) return;
        JilSerializer.Pack(value, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions);
    }

    public static TValue? Unpack<TValue>(Stream? stream, Options? options = null, Encoding? encoding = null) =>
        stream is null
            ? default
            : JilSerializer.Unpack<TValue>(stream!, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static object? Unpack(Type type, Stream? stream, Options? options = null, Encoding? encoding = null) =>
        stream is null
            ? default
            : JilSerializer.Unpack(type, stream!, encoding ?? DefaultEncoding, options ?? DefaultOptions);
}