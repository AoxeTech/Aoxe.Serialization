namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Serialize the object to ini and write it to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream = null, Encoding? encoding = null) =>
        Pack(typeof(TValue), value, stream, encoding);

    /// <summary>
    /// Serialize the object to ini and write it to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    public static void Pack(object? value, Stream? stream = null, Encoding? encoding = null)
    {
        if (stream is null || value is null) return;
        Pack(value.GetType(), value, stream, encoding);
    }

    /// <summary>
    /// Serialize the object to ini and write it to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    public static void Pack(Type type, object? value, Stream? stream = null, Encoding? encoding = null)
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
        var bytes = (encoding ?? Defaults.Utf8Encoding).GetBytes(data.ToString());
#if NETSTANDARD2_0
        stream.Write(bytes, 0, bytes.Length);
#else
        stream.Write(bytes);
#endif
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}