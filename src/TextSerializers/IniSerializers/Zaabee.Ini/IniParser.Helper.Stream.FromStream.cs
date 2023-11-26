namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Deserialize from stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream, Encoding? encoding = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var obj = FromStream(typeof(TValue), stream, encoding);
        return obj is null ? default : (TValue)obj;
    }

    /// <summary>
    /// Deserialize from stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream, Encoding? encoding = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var parser = new IniDataParser();
        var bytes = stream.ReadToEnd();
        var iniData = parser.Parse((encoding ?? Defaults.Utf8Encoding).GetString(bytes));

        var obj = Activator.CreateInstance(type);
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var sectionName = property.DeclaringType?.Name;
            var propertyName = property.Name;
            var value = iniData[sectionName][propertyName];
            if (string.IsNullOrEmpty(value))
                continue;
            var propertyType = property.PropertyType;
            var convertedValue = Convert.ChangeType(
                TypeDescriptor.GetConverter(propertyType).ConvertFromInvariantString(value),
                propertyType
            );
            property.SetValue(obj, convertedValue);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return obj;
    }
}
