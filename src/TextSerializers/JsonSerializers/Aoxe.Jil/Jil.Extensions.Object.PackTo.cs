namespace Aoxe.Jil;

public static partial class JilExtensions
{
    public static void PackTo<TValue>(
        this TValue? value,
        Stream? stream,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.Pack(value, stream, options, encoding);

    public static void PackTo(
        this object? value,
        Stream? stream,
        Options? options = null,
        Encoding? encoding = null
    ) => JilHelper.Pack(value, stream, options, encoding);
}
