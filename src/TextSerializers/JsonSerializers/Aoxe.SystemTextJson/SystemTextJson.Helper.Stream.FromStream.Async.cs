namespace Aoxe.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Asynchronously reads the UTF-8 encoded text representing a single JSON value into an instance of a type
    /// specified by a generic type parameter.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = await JsonSerializer.DeserializeAsync<TValue>(
            stream,
            options,
            cancellationToken
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Asynchronously reads the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = await JsonSerializer.DeserializeAsync(
            stream,
            type,
            options,
            cancellationToken
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
