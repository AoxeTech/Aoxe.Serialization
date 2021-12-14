using System.Threading;

namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.PackAsync(value, stream, cancellationToken);
}