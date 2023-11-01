namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static MemoryStream ToStream<TValue>(
        this TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.ToStream(value, tomlSerializerOptions, encoding);
}