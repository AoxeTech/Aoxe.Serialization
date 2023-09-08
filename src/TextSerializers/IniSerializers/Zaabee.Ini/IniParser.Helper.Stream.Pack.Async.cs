namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Serialize the object to ini and write it to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    public static ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        PackAsync(typeof(TValue), value, stream, encoding, cancellationToken);

    /// <summary>
    /// Serialize the object to ini and write it to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    public static ValueTask PackAsync(
        object? value,
        Stream? stream = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        if (stream is null || value is null) return default;
        return PackAsync(value.GetType(), value, stream, encoding, cancellationToken);
    }

    /// <summary>
    /// Serialize the object to ini and write it to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    public static async ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        if (stream is null || value is null) return;
        var data = new IniData();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var sectionName = property.DeclaringType?.Name;
            var propertyName = property.Name;
            var propValue = property.GetValue(value)?.ToString() ?? "";
            data[sectionName][propertyName] = propValue;
        }
        var bytes = data.ToString().GetBytes(encoding ?? Defaults.Utf8Encoding);
#if NETSTANDARD2_0
        await stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
#else
        await stream.WriteAsync(bytes, cancellationToken);
#endif
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}