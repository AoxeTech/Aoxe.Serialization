namespace Aoxe.Tomlyn;

public static partial class TomlynExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null
    )
        where TValue : class, new() =>
        TomlynHelper.FromStream<TValue>(stream, sourcePath, tomlModelOptions, encoding);

    public static TomlTable? FromStream(
        this Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null
    ) => TomlynHelper.FromStream(stream, sourcePath, tomlModelOptions, encoding);
}
