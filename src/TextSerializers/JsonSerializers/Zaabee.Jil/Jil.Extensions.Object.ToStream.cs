namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static MemoryStream ToStream<TValue>(
        this TValue? value,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.ToStream(value, options, encoding);

    public static MemoryStream ToStream(
        this object? value,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.ToStream(value, options, encoding);
}
