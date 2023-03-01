namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetHelper
{
    public static TValue? FromStream<TValue>(Stream? stream, Encoding? encoding = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = FromBytes<TValue>(stream.ReadToEnd(), encoding ?? DefaultEncoding);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static object? FromStream(Type type, Stream? stream, Encoding? encoding = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = FromBytes(type, stream.ReadToEnd(), encoding ?? DefaultEncoding);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}