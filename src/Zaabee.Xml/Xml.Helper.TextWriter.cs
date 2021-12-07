namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static void Serialize<TValue>(TextWriter? textWriter, TValue? value)
    {
        if (textWriter is null || value is null) return;
        XmlSerializer.Serialize<TValue>(textWriter, value);
    }

    public static void Serialize(Type type, TextWriter? textWriter, object? value)
    {
        if (textWriter is null || value is null) return;
        XmlSerializer.Serialize(type, textWriter, value);
    }
}