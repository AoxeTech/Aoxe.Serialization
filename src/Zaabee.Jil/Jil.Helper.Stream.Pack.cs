namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static void Pack<TValue>(TValue? value, Stream? stream, Options? options = null, Encoding? encoding = null)
    {
        if (stream is null) return;
        JilSerializer.Pack(value, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions);
    }

    public static void Pack(object? value, Stream? stream, Options? options = null, Encoding? encoding = null)
    {
        if (stream is null) return;
        JilSerializer.Pack(value, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions);
    }
}