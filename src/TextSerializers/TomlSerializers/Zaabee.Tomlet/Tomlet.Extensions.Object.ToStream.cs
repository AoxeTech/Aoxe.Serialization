namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static MemoryStream ToStream<TValue>(
        this TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.ToStream(value, tomlSerializerOptions, encoding);

    public static MemoryStream ToStream(
        this object? value,
        Type type,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.ToStream(type, value, tomlSerializerOptions, encoding);
}