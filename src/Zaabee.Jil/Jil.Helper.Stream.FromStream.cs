namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static TValue? FromStream<TValue>(Stream? stream, Options? options = null, Encoding? encoding = null) =>
        stream is null
            ? default
            : JilSerializer.FromStream<TValue>(stream, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static object? FromStream(Type type, Stream? stream, Options? options = null, Encoding? encoding = null) =>
        stream is null
            ? default
            : JilSerializer.FromStream(type, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions);
}