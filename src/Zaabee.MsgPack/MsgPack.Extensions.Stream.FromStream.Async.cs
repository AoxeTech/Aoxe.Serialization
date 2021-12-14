using System.Threading;

namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.FromStreamAsync<TValue>(stream, cancellationToken);
}