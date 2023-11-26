namespace Zaabee.Serializer.Abstractions;

public partial interface IStreamSerializerAsync
{
    /// <summary>
    /// If the stream is null or empty will return the default value of T.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// If the stream is null or empty will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    );
}
