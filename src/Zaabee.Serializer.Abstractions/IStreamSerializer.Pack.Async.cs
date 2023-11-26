namespace Zaabee.Serializer.Abstractions;

public partial interface IStreamSerializerAsync
{
    /// <summary>
    /// Serialize the value and pack to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Serialize the value and pack to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    );
}
