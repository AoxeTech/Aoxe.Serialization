using System.Threading;

namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task PackToAsync<TValue>(this TValue? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.PackAsync(value, stream, cancellationToken);
}