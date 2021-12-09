namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static Stream ToStream<TValue>(this TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.ToStream(value, options, encoding);

    public static Stream ToStream(this object? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.ToStream(value, options, encoding);
}