namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Serialize(value, options, encoding);

    public static Stream ToStream<TValue>(this TValue? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Pack(value, options, encoding);

    public static string ToJson<TValue>(this TValue? value, Options? options = null) =>
        JilHelper.SerializeToJson(value, options);

    public static void ToJson<TValue>(this TValue? value, TextWriter output, Options? options = null) =>
        JilHelper.Serialize(value, output, options);

    public static void PackTo<TValue>(this TValue? value, Stream? stream, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Pack(value, stream, options, encoding);

    public static byte[] ToBytes(this object? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Serialize(value, options, encoding);

    public static Stream ToStream(this object? value, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Pack(value, options, encoding);

    public static string ToJson(this object? value, Options? options = null) =>
        JilHelper.SerializeToJson(value, options);

    public static void PackTo(this object? value, Stream? stream, Options? options = null, Encoding? encoding = null) =>
        JilHelper.Pack(value, stream, options, encoding);

    public static void ToJson(this object? value, TextWriter output, Options? options = null) =>
        JilHelper.Serialize(value, output, options);
}