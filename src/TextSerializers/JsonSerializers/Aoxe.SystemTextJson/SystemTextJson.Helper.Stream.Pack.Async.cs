namespace Aoxe.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await JsonSerializer.SerializeAsync(stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await JsonSerializer.SerializeAsync(stream, value, type, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
