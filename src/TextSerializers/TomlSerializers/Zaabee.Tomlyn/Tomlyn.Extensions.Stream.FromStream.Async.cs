namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    )
        where TValue : class, new() =>
        TomlynHelper.FromStreamAsync<TValue>(
            stream,
            sourcePath,
            tomlModelOptions,
            encoding,
            cancellationToken: cancellationToken
        );

    public static ValueTask<TomlTable?> FromStreamAsync(
        this Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) =>
        TomlynHelper.FromStreamAsync(
            stream,
            sourcePath,
            tomlModelOptions,
            encoding,
            cancellationToken
        );
}
