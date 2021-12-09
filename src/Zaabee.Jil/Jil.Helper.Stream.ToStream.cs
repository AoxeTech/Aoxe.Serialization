namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static Stream ToStream<TValue>(TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.ToStream(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);

    public static Stream ToStream(object? value, Options? options = null, Encoding? encoding = null) =>
        JilSerializer.ToStream(value, encoding ?? DefaultEncoding, options ?? DefaultOptions);
}